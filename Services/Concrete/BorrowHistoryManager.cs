using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace libAPI.Services.Concrete
{
	public class BorrowHistoryManager : GenericManager<BorrowHistory, BorrowHistoryDTO, libAPIContext, int>, IBarrowHistoryService
	{
		public BorrowHistoryManager(IRepository<BorrowHistory, libAPIContext, int> repository) : base(repository)
		{
		}

	
		public async Task<BorrowHistory> GetByMemberAndBookAsync(string memberId, int bookId) {

			return await ((IBorrowHistoryRepository)_repository).GetByMemberAndBookAsync(memberId, bookId);

		}

		protected override BorrowHistory MapToEntity(BorrowHistoryDTO dto)
		{
			return new BorrowHistory
			{
				Id = dto.Id,
				MemberId = dto.MemberId,
				BookId = dto.BookId,
				BorrowedDate = dto.BorrowedDate,
				ReturnedDate = dto.ReturnedDate,
				IsReturned = dto.IsReturned,
				IsPenaltyApplied = dto.IsPenaltyApplied
			};
		}

		protected override BorrowHistoryDTO MapToDto(BorrowHistory entity)
		{
			return new BorrowHistoryDTO
			{
				Id = entity.Id,
				MemberId = entity.MemberId,
				BookId = entity.BookId,
				BorrowedDate = entity.BorrowedDate,
				ReturnedDate = entity.ReturnedDate,
				IsReturned = entity.IsReturned,
				IsPenaltyApplied = entity.IsPenaltyApplied
			};
		}


	}
}
