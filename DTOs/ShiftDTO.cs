﻿using System.ComponentModel.DataAnnotations;

namespace libAPI.DTOs
{
	public class ShiftDTO
	{
		public short Id { get; set; }

		[StringLength(50)]
		public string Name { get; set; } = string.Empty;
	}

}