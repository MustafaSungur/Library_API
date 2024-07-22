namespace libAPI.DTOs
{
	public class PublisherCreateDTO
	{
		public int Id { get; set; }

		public string Name { get; set; } = string.Empty;

		public string? Phone { get; set; }

		public string? Email { get; set; }

		public string? ContactPerson { get; set; }
	}

	public class PublisherReadDTO
	{
		public int Id { get; set; }

		public string Name { get; set; } = string.Empty;

		public string? Phone { get; set; }

		public string? Email { get; set; }

		public string? ContactPerson { get; set; }
	}
}
