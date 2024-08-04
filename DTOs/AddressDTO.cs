namespace libAPI.DTOs
{
	public class AddressCreateDTO
	{
		public int Id { get; set; }

		public short AddressCountryId { get; set; }
		public short AddressCityId { get; set; }
		public string ClearAddress { get; set; } = string.Empty;
	}

	public class AddressReadDTO
	{
		public int Id { get; set; }
		public AddressCityReadDTO? City { get; set; }
		public AddressCountryReadDTO? Country { get; set; }
		public string ClearAddress { get; set; } = string.Empty;
	}
}
