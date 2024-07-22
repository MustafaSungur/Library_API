
	namespace libAPI.DTOs
	{
		public class ShiftCreateDTO
		{
		public short Id { get; set; }

		public string Name { get; set; } = string.Empty;
		}

		public class ShiftReadDTO
		{
			public short Id { get; set; }
			public string Name { get; set; } = string.Empty;
		}
	}


