﻿using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;

namespace libAPI.Services.Concrete
{
	public class EducationalDegreeManager : GenericManager<EducationalDegree, EducationalDegreeDTO, libAPIContext,int>, IEducationalDegreeService
	{
		public EducationalDegreeManager(IRepository<EducationalDegree, libAPIContext,int> repository) : base(repository)
		{
		}

		protected override EducationalDegree MapToEntity(EducationalDegreeDTO dto)
		{
			return new EducationalDegree
			{
				Id = dto.Id,
				Degree = dto.Degree
			};
		}

		protected override EducationalDegreeDTO MapToDto(EducationalDegree entity)
		{
			return new EducationalDegreeDTO
			{
				Id = entity.Id,
				Degree = entity.Degree
			};
		}

	}
}