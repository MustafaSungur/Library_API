using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using System;
using System.Net;
using System.Threading.Tasks;

namespace libAPI.Services.Concrete
{
	public class BorrowBooksManager : GenericManager<BorrowBooks, BorrowBooksCreateDTO, BorrowBooksReadDTO, libAPIContext, int>, IBorrowBooksService
	{
		private readonly IMemberService _memberService;
		private readonly IStockRepository _stockRepository;
		private readonly IBookRepository _bookRepository;
		private readonly IBorrowHistoryRepository _borrowHistoryRepository;
		private readonly IConfiguration _configuration;

		public BorrowBooksManager(
			IBorrowBooksRepository repository,
			IMemberService memberService,
			IBookRepository bookRepository,
			IStockRepository stockRepository,
			IBorrowHistoryRepository borrowHistoryRepository,
			IConfiguration configuration)
			: base(repository)
		{
			_memberService = memberService;
			_bookRepository = bookRepository;
			_stockRepository = stockRepository;
			_borrowHistoryRepository = borrowHistoryRepository;
			_configuration = configuration;
		}

		public  async Task<IEnumerable<BorrowBooksReadDTO>> AddListAsync(BorrowBooksCreateDTO borrowBookDto)
		{
			var member = await _memberService.GetByIdAsync(borrowBookDto.MemberId);

			if (member == null)
			{
				throw new Exception("Member not found.");
			}

			if (member.IsBanned)
			{
				var penaltyControl = member.EndBannedDate > DateTime.Now;
				if (penaltyControl)
				{
					member.IsBanned = false;
					member.PenaltyPoint = 0;
					var memberDto = _memberService.MapToCreateDto(member);
					await _memberService.UpdateAsync(memberDto);
				}
				else
				{
					throw new Exception("Member is banned.");
				}
			}

			var borrowBooksList = new List<BorrowBooksReadDTO>();
		
			foreach (var bookId in borrowBookDto.BooksId)
			{
				var book = await _bookRepository.GetByIdAsync(bookId);
				var stock = await _stockRepository.GetByIdAsync(book.ISBM);

				if (stock == null)
				{
					throw new Exception($"Book with ID {bookId} not found");
				}


				var duplicateLoanControl = await ((IBorrowBooksRepository)_repository).GetMemberIdAndBookIdAsync(member.Id, bookId);
				if (duplicateLoanControl != null)
				{
					throw new Exception("Borrowing the same book again without returning it");
				}

				if (stock.AvailableCopies < 1)
				{
					throw new Exception($"Book with ID {bookId} is not available");
				}
				else
				{
					stock.AvailableCopies -= 1;
					

					await _stockRepository.UpdateAsync(stock);

					var borrowHistory = new BorrowHistory
					{
						MemberId = member.Id,
						BookId = bookId,
						BorrowedDate = DateTime.Now,
						IsReturned = false,
						IsPenaltyApplied = false,
					};
					await _borrowHistoryRepository.AddAsync(borrowHistory);

					var borrowBook = new BorrowBooks
					{
						BookId = bookId,
						MemberId = member.Id,
						RentalDate = DateTime.Now,
						Deadline = DateTime.Now.AddDays(14) 
					};

					var createdBorrowBook = await _repository.AddAsync(borrowBook);
					var TempBarrowBook = await _repository.GetByIdAsync(createdBorrowBook.Id);
					var ReadDto = MapToDto(TempBarrowBook);
					borrowBooksList.Add(ReadDto);
				}
			}


			return borrowBooksList;
		}


		public override async Task<bool> DeleteAsync(int id)
		{
			var borrowedBookDto = await GetByIdAsync(id);

			if (borrowedBookDto == null)
			{
				throw new Exception("Borrowed Book not found.");
			}

			var member = await _memberService.GetByIdAsync(borrowedBookDto.Member.Id);
			if (member == null)
			{
				throw new Exception("Member not found.");
			}

			var borrowHistory = await _borrowHistoryRepository.GetByMemberAndBookAsync(member.Id, borrowedBookDto.Book.Id);
			if (borrowHistory == null)
			{
				throw new Exception("Borrow history not found.");
			}

			TimeSpan penaltyPeriod = DateTime.Now - borrowedBookDto.Deadline;
			if (penaltyPeriod.TotalDays > 0)
			{
				member.PenaltyPoint += (short)penaltyPeriod.TotalDays;
				borrowHistory.IsPenaltyApplied = true;

				if (member.PenaltyPoint > 7)
				{
					int bannedDays = int.Parse(_configuration["BannedDays"]);
					member.IsBanned = true;
					member.EndBannedDate = DateTime.Now.AddDays(bannedDays);
				}


			
				var memberCreateDto = _memberService.MapToCreateDto(member);
				await _memberService.UpdateAsync(memberCreateDto);
			}

			borrowHistory.ReturnedDate = DateTime.Now;
			borrowHistory.IsReturned = true;
			await _borrowHistoryRepository.UpdateAsync(borrowHistory);

			var stock = await _stockRepository.GetByIdAsync(borrowedBookDto.Book.ISBM);
			if (stock != null)
			{
				stock.AvailableCopies += 1;
				

				await _stockRepository.UpdateAsync(stock);
			}

			return await base.DeleteAsync(id);
		}

		public override BorrowBooks MapToEntity(BorrowBooksCreateDTO dto)
		{
			return new BorrowBooks
			{
			
				MemberId = dto.MemberId,
				RentalDate = dto.RentalDate,
				Deadline = dto.Deadline,
				BooksId = dto.BooksId,
			};
		}

		public override BorrowBooksReadDTO MapToDto(BorrowBooks entity)
		{
			return new BorrowBooksReadDTO
			{
				Id = entity.Id,
				RentalDate = entity.RentalDate,
				Deadline = entity.Deadline,
				Member = new MemberReadDTO
				{
					Id = entity.Member.Id,
					ApplicationUserReadDTO = new ApplicationUserReadDTO
					{
						Id = entity.Member.ApplicationUser.Id,
						FirstName = entity.Member.ApplicationUser.FirstName,
						LastName = entity.Member.ApplicationUser.LastName,
						
						Address = new AddressReadDTO
						{
							Id = entity.Member.ApplicationUser.Address.Id,
							Country = new AddressCountryReadDTO
							{
								Id = entity.Member.ApplicationUser.Address.Country.Id,
								Name = entity.Member.ApplicationUser.Address.Country.Name,

							},
							City = new AddressCityReadDTO
							{
								Id = (short)entity.Member.ApplicationUser.Address.City.Id,
								Name = entity.Member.ApplicationUser.Address.City.Name,
							},
							ClearAddress = entity.Member.ApplicationUser.Address.ClearAddress
						},
						BirthDate = entity.Member.ApplicationUser.BirthDate,
						RegisterDate = entity.Member.ApplicationUser.RegisterDate,
						Status = entity.Member.ApplicationUser.Status,
						PhotoUrl = entity.Member.ApplicationUser.PhotoUrl
					},
					
					PenaltyPoint = entity.Member.PenaltyPoint,
					IsBanned = entity.Member.IsBanned,
					EndBannedDate = entity.Member.EndBannedDate
				},
				Book = new BookReadDTO
				{
					Id = entity.Book.Id,
					Title = entity.Book.Title,
					ISBM = entity.Book.ISBM,
					PageCount = entity.Book.PageCount,
					PublishingYear = entity.Book.PublishingYear,
					Description = entity.Book.Description,
					PrintCount = entity.Book.PrintCount,
					PublisherId = entity.Book.PublisherId,
					LocationId = entity.Book.LocationId,
					PhotoUrl = entity.Book.PhotoUrl,
					RegisterDate = entity.Book.RegisterDate,
					Stock = entity.Book.Stock,
					Authors = entity.Book.AuthorBooks.Select(ab => new AuthorReadDTO
					{
						Id = ab.Author.Id,
						FullName = ab.Author.FullName
					}).ToList(),
					Languages = entity.Book.LanguageBooks.Select(lb => new LanguageReadDTO
					{
						Code = lb.Language.Code,
						Name = lb.Language.Name
					}).ToList(),
					SubCategories = entity.Book.SubCategoryBooks.Select(sb => new SubCategoryReadDTO
					{
						Id = sb.SubCategory.Id,
						Name = sb.SubCategory.Name
					}).ToList()
				},
			};
		}
	}
}
