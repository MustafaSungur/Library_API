using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;


namespace libAPI.Services.Concrete
{
	public class BorrowHistoryManager : GenericManager<BorrowHistory, BorrowHistoryCreateDTO, BorrowHistoryReadDTO, libAPIContext, int>, IBorrowHistoryService
	{
		private readonly IBorrowHistoryRepository _borrowHistoryRepository;
		public BorrowHistoryManager(IBorrowHistoryRepository repository) : base(repository)
		{
			_borrowHistoryRepository = repository;
		}

		public async Task<BorrowHistoryReadDTO> GetByMemberAndBookAsync(string memberId, int bookId)
		{

			var borrowHistory = await _borrowHistoryRepository.GetByMemberAndBookAsync( memberId, bookId);

			return MapToDto(borrowHistory);
;		}



		public async Task<List<BorrowHistoryReadDTO>> GetAllByMemberIdAsync(string memberId)
		{
			var borrowHistories = await _borrowHistoryRepository.GetAllByMemberIdAsync(memberId);
			var borrowHistoryDtos = borrowHistories.Select(e => MapToDto(e)).ToList();
			return borrowHistoryDtos;
		}


		public override async Task<BorrowHistoryReadDTO> AddAsync(BorrowHistoryCreateDTO dto)
		{
			
			var entity = MapToEntity(dto);
			entity.RegisterDate = DateTime.Now;
			await _repository.AddAsync(entity);
			return MapToDto(entity);
		}


		public override BorrowHistory MapToEntity(BorrowHistoryCreateDTO dto)
		{
			return new BorrowHistory
			{
				MemberId = dto.MemberId,
				BookId = dto.BookId,
				BorrowedDate = dto.BorrowedDate,
				ReturnedDate = dto.ReturnedDate,
				IsReturned = dto.IsReturned,
				IsPenaltyApplied = dto.IsPenaltyApplied
			};
		}

		public override BorrowHistoryReadDTO MapToDto(BorrowHistory entity)
		{
			return new BorrowHistoryReadDTO
			{
				Id = entity.Id,
				MemberId = entity.MemberId,
				BorrowedDate = entity.BorrowedDate,
				ReturnedDate = entity.ReturnedDate,
				IsReturned = entity.IsReturned,
				IsPenaltyApplied = entity.IsPenaltyApplied,
				RegisterDate = entity.RegisterDate,

				
				Book = new BookReadDTO
				{
					Id = entity!.Book!.Id!,
					Title = entity.Book.Title,
					ISBM = entity.Book!.ISBM!,
					PageCount = entity.Book.PageCount,
					PublishingYear = entity.Book.PublishingYear,
					Description = entity.Book!.Description!,
					PrintCount = entity.Book.PrintCount,
					PublisherId = entity.Book.PublisherId,
					LocationId = entity.Book.LocationId,
					PhotoUrl = entity.Book!.PhotoUrl!,
					RegisterDate = entity.Book.RegisterDate,
					Stock = entity.Book.Stock,
					Authors = entity.Book!.AuthorBooks!.Select(ab => new AuthorReadDTO
					{
						Id = ab.Author!.Id,
						FullName = ab.Author.FullName
					}).ToList(),
					Languages = entity.Book!.LanguageBooks!.Select(lb => new LanguageReadDTO
					{
						Code = lb.Language!.Code,
						Name = lb.Language.Name
					}).ToList(),
					SubCategories = entity.Book!.SubCategoryBooks!.Select(sb => new SubCategoryReadDTO
					{
						Id = sb.SubCategory!.Id,
						Name = sb.SubCategory.Name
					}).ToList()
				},

			    BorrowingEmployeeId = entity.BorrowingEmployee?.Id,
			    BorrowingEmployeeFirstName = entity.BorrowingEmployee?.ApplicationUser?.FirstName,
			    BorrowingEmployeeLastName = entity.BorrowingEmployee?.ApplicationUser?.LastName,
				LendingEmployeeId = entity.LendingEmployee?.Id ?? "",
				LendingEmployeeFirstName = entity.LendingEmployee?.ApplicationUser?.FirstName ?? "",
				LendingEmployeeLastName = entity.LendingEmployee?.ApplicationUser?.LastName ?? "",
			};
		}

	
	}
}
