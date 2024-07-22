using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;
using System.Threading.Tasks;

namespace libAPI.Services.Concrete
{
    public class MemberManager : GenericManager<Member, MemberCreateDTO, MemberReadDTO, libAPIContext, string>, IMemberService
    {
        private readonly IAddressService _addressService;
        private readonly IEducationalDegreeService _educationalDegreeService;

        public MemberManager(
           IMemberRepository repository,
            IAddressService addressService,
            IEducationalDegreeService educationalDegreeService) : base(repository)
        {
            _addressService = addressService;
            _educationalDegreeService = educationalDegreeService;
        }

		public override async Task<MemberReadDTO> AddAsync(MemberCreateDTO dto)
		{
			var addressDto = await _addressService.AddAsync(dto.ApplicationUserCreateDTO.Address);

			var entity = new Member
			{
				ApplicationUser = new ApplicationUser
				{
					FirstName = dto.ApplicationUserCreateDTO.FirstName,
					LastName = dto.ApplicationUserCreateDTO.LastName,
					GenderId = dto.ApplicationUserCreateDTO.GenderId,
					AddressId = addressDto.Id,
					BirthDate = dto.ApplicationUserCreateDTO.BirthDate,
					PhotoUrl = dto.ApplicationUserCreateDTO.PhotoUrl,
					Password = dto.ApplicationUserCreateDTO.Password,
					Email = dto.ApplicationUserCreateDTO.Email,
					PhoneNumber = dto.ApplicationUserCreateDTO.PhoneNumber,
					Status = true,
					RegisterDate = DateTime.Now,
				},
				EducationalDegreeId = dto.EducationalDegreeId,
				PenaltyPoint = 0, 
				IsBanned = false, 
				EndBannedDate = null 
			};

			var result = await _repository.AddAsync(entity);

			var newMember = await _repository.GetByIdAsync(result.Id);

			return MapToDto(newMember);
		}


		public override Member MapToEntity(MemberCreateDTO dto)
        {
            return new Member
            {
                ApplicationUser = new ApplicationUser
                {
                    FirstName = dto.ApplicationUserCreateDTO.FirstName,
                    LastName = dto.ApplicationUserCreateDTO.LastName,
                    GenderId = dto.ApplicationUserCreateDTO.GenderId,
                    Address = new Address
                    {
                        AddressCountryId = dto.ApplicationUserCreateDTO.Address.AddressCountryId,
                        AddressCityId = dto.ApplicationUserCreateDTO.Address.AddressCityId,
                        ClearAddress = dto.ApplicationUserCreateDTO.Address.ClearAddress
                    },
                    BirthDate = dto.ApplicationUserCreateDTO.BirthDate,
                    PhotoUrl = dto.ApplicationUserCreateDTO.PhotoUrl,
                    Password = dto.ApplicationUserCreateDTO.Password
                },
                EducationalDegreeId=dto.EducationalDegreeId,
              
            };
        }

		public override MemberReadDTO MapToDto(Member entity)
		{
			var applicationUser = entity.ApplicationUser;
			var address = applicationUser?.Address;

			return new MemberReadDTO
			{
				Id = entity.Id,
				ApplicationUserReadDTO = applicationUser == null ? null : new ApplicationUserReadDTO
				{
					Id = applicationUser.Id,
					FirstName = applicationUser.FirstName,
					LastName = applicationUser.LastName,
					Gender = new GenreReadDTO
					{
						Id = applicationUser.GenderId,
						Name = applicationUser.Gender?.Name
					},
					Address = address == null ? null : new AddressReadDTO
					{
						Id = address.Id,
						City = address.City == null ? null : new AddressCityReadDTO
						{
							Id = address.City.Id,
							Name = address.City.Name
						},
						Country = address.Country == null ? null : new AddressCountryReadDTO
						{
							Id = address.Country.Id,
							Name = address.Country.Name
						},
						ClearAddress = address.ClearAddress
					},
					BirthDate = applicationUser.BirthDate,
					RegisterDate = applicationUser.RegisterDate,
					Status = applicationUser.Status,
					PhotoUrl = applicationUser.PhotoUrl
				},
				EducationalDegree = entity.EducationalDegree == null ? null : new EducationalReadDTO
				{
					Id = entity.EducationalDegree.Id,
					Degree = entity.EducationalDegree.Degree
				},
				PenaltyPoint = entity.PenaltyPoint,
				IsBanned = entity.IsBanned,
				EndBannedDate = entity.EndBannedDate
			};
		}



		public override MemberCreateDTO MapToCreateDto(MemberReadDTO member)
		{
			var applicationUser = member.ApplicationUserReadDTO;
			var address = applicationUser?.Address;

			return new MemberCreateDTO
			{
				ApplicationUserCreateDTO = applicationUser == null ? null : new ApplicationUserCreateDTO
				{
					FirstName = applicationUser.FirstName,
					LastName = applicationUser.LastName,
					GenderId = applicationUser.Gender?.Id ?? 0, // Handle null Gender
					Address = address == null ? null : new AddressCreateDTO
					{
						AddressCountryId = address.Country.Id,
						AddressCityId = address.City.Id,
						ClearAddress = address.ClearAddress
					},
					BirthDate = applicationUser.BirthDate,
					PhotoUrl = applicationUser.PhotoUrl
				},
				EducationalDegreeId = member.EducationalDegree?.Id ?? 0 // Handle null EducationalDegree
			};
		}

	}
}
