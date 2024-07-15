﻿using libAPI.Data;
using libAPI.Models;

namespace libAPI.Services.Abstract
{
	public interface IBookService:IService<Book, libAPIContext,int>
	{
	}
}
