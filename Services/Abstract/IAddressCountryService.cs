﻿using libAPI.Data;
using libAPI.DTOs;
using libAPI.Models;

namespace libAPI.Services.Abstract
{
	public interface IAddressCountryService:IService<AddressCountry, AddressCountryDTO, libAPIContext,int>
	{
	}
}