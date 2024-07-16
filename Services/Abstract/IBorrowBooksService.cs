﻿using libAPI.Data;
using libAPI.DTOs;
using libAPI.Models;

namespace libAPI.Services.Abstract
{
	public interface IBorrowBooksService:IService<BorrowBooks, BorrowBooksDTO, libAPIContext, int>
	{
	}
}