﻿using libAPI.Data;
using libAPI.DTOs;
using libAPI.Models;

namespace libAPI.Services.Abstract
{
	public interface ICategoryService:IService<Category, CategoryCreateDTO, CategoryReadDTO, libAPIContext, short>
	{
	}
}
