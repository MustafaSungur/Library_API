namespace libAPI.DTOs
{
	public class AddressDTO
	{
		public int Id { get; set; }
		public short AddressCountryId { get; set; }
		public short AddressCityId { get; set; }
		public string ClearAddress { get; set; } = string.Empty;
	}

}
