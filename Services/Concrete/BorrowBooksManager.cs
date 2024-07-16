using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace libAPI.Services.Concrete
{
	public class BorrowBooksManager : GenericManager<BorrowBooks, BorrowBooksDTO, libAPIContext, int>, IBorrowBooksService
	{
		private readonly IMemberService _memberService;
		private readonly IStockService _stockService;
		private readonly IBorrowHistoryRepository _borrowHistoryService;
		private readonly IConfiguration _configuration;

		public BorrowBooksManager(
			IRepository<BorrowBooks, libAPIContext, int> repository,
			IMemberService memberService,
			IStockService stockService,
			IBorrowHistoryRepository borrowHistoryService,
			IConfiguration configuration)
			: base(repository)
		{
			_memberService = memberService;
			_stockService = stockService;
			_borrowHistoryService = borrowHistoryService;
			_configuration = configuration;
		}

		public override async Task<BorrowBooksDTO> AddAsync(BorrowBooksDTO borrowBookDto)
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
					await _memberService.UpdateAsync(member);
				}
				else
				{
					throw new Exception("Member is banned.");
				}
			}

			var stock = await _stockService.GetStockByBookIdAsync(borrowBookDto.BookId);
			if (stock == null)
			{
				throw new Exception("Stock not found");
			}

			if (stock.AvailableCopies < 1)
			{
				throw new Exception("Book not available");
			}
			else
			{
				stock.AvailableCopies -= 1;
				await _stockService.UpdateAsync(stock);

				var borrowHistory = new BorrowHistory
				{
					MemberId = member.Id,
					BookId = borrowBookDto.BookId,
					BorrowedDate = DateTime.Now,
					IsReturned = false,
					IsPenaltyApplied = false,
				};

				await _borrowHistoryService.AddAsync(borrowHistory);
			}

			var borrowBook = MapToEntity(borrowBookDto);
			await base.AddAsync(borrowBook);
			return borrowBookDto;
		}

		public override async Task<bool> DeleteAsync(int id)
		{
			var borrowedBookDto = await GetByIdAsync(id);

			if (borrowedBookDto == null)
			{
				throw new Exception("Borrowed Book not found.");
			}

			var member = await _memberService.GetByIdAsync(borrowedBookDto.MemberId);
			if (member == null)
			{
				throw new Exception("Member not found.");
			}

			var borrowHistory = await _borrowHistoryService.GetByMemberAndBookAsync(member.Id, borrowedBookDto.BookId);
			if (borrowHistory == null)
			{
				throw new Exception("Borrow history not found.");
			}

			if (borrowedBookDto.Deadline < DateTime.Now)
			{
				member.PenaltyPoint += 1;
				borrowHistory.IsPenaltyApplied = true;

				if (member.PenaltyPoint > 5)
				{
					int bannedDays = int.Parse(_configuration["BannedDays"]);
					member.IsBanned = true;
					member.EndBannedDate = DateTime.Now.AddDays(bannedDays);
				}

				await _memberService.UpdateAsync(member);
			}

			borrowHistory.ReturnedDate = DateTime.Now;
			borrowHistory.IsReturned = true;
			await _borrowHistoryService.UpdateAsync(borrowHistory);

			var stock = await _stockService.GetStockByBookIdAsync(borrowedBookDto.BookId);
			if (stock != null)
			{
				stock.AvailableCopies += 1;
				await _stockService.UpdateAsync(stock);
			}

			return await base.DeleteAsync(id);
		}

		protected override BorrowBooks MapToEntity(BorrowBooksDTO dto)
		{
			return new BorrowBooks
			{
				Id = dto.Id,
				BookId = dto.BookId,
				MemberId = dto.MemberId,
				RentalDate = dto.RentalDate,
				Deadline = dto.Deadline,
				BooksId = dto.BooksId
			};
		}

		protected override BorrowBooksDTO MapToDto(BorrowBooks entity)
		{
			return new BorrowBooksDTO
			{
				Id = entity.Id,
				BookId = entity.BookId,
				MemberId = entity.MemberId,
				RentalDate = entity.RentalDate,
				Deadline = entity.Deadline,
				BooksId = entity.BooksId
			};
		}
	}
}
