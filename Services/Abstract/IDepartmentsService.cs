﻿using libAPI.Data;
using libAPI.DTOs;
using libAPI.Models;

namespace libAPI.Services.Abstract
{
	public interface IDepartmentsService : IService<Department, DepartmentCreateDTO, DepartmentReadDTO, libAPIContext, short>
	{
		
	}
}
