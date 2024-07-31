using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;
using Microsoft.AspNetCore.Identity;

namespace libAPI.Services.Concrete
{
    public class MemberManager : GenericManager<Member, MemberCreateDTO, MemberReadDTO, libAPIContext, string>, IMemberService
    {
        private readonly IAddressService _addressService;
		private readonly UserManager<ApplicationUser> _userManager;

		public MemberManager(
           IMemberRepository repository,
           IAddressService addressService,
           UserManager<ApplicationUser> userManager) : base(repository)
        {
            _addressService = addressService;
			_userManager = userManager;
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
			entity.ApplicationUser!.UserName = entity!.ApplicationUser!.Email;
			entity.ApplicationUser!.NormalizedUserName = entity.ApplicationUser!.Email.Trim().ToLowerInvariant();
			entity.ApplicationUser!.Email = entity.ApplicationUser!.Email.Trim().ToLowerInvariant();
			entity.ApplicationUser!.NormalizedEmail = entity.ApplicationUser!.Email.ToUpperInvariant();
			await _userManager.CreateAsync(entity.ApplicationUser!, entity.ApplicationUser!.Password);
			await _userManager.AddToRoleAsync(entity.ApplicationUser, "Member");
			var result = _repository.AddAsync(entity).Result;

			var newMember = await _repository.GetByIdAsync(result.Id);

			return MapToDto(newMember);
		}

		public  async Task<string> BanMember(string memberId)
		{
			var member = await _repository.GetByIdAsync(memberId);

			if (member == null)
			{
				throw new Exception("Member Not Found");
			}

			member.IsBanned= true;

			return "Member Banned";
		}

		public async Task<string> RemoveBanMember(string memberId)
		{
			var member = await _repository.GetByIdAsync(memberId);

			if (member == null)
			{
				throw new Exception("Member Not Found");
			}

			member.IsBanned = false;

			return "Member Removed Ban";
		}



		public  async Task<MemberReadDTO> UpdateAsync(string memberId, MemberCreateDTO dto)
		{
			// Retrieve the existing member
			var existingMember = await _repository.GetByIdAsync(memberId);
			if (existingMember == null)
			{
				throw new Exception("Member not found");
			}

			// Update the address if necessary
			var updatedAddressDto = await _addressService.UpdateAsync(dto.ApplicationUserCreateDTO.Address);

			// Update the application user details
			var user = existingMember.ApplicationUser;
			if (user == null)
			{
				throw new Exception("Associated user not found");  // Ideally handle more gracefully
			}

			user.FirstName = dto.ApplicationUserCreateDTO.FirstName;
			user.LastName = dto.ApplicationUserCreateDTO.LastName;
			user.GenderId = dto.ApplicationUserCreateDTO.GenderId;
			user.AddressId = updatedAddressDto.Id;
			user.BirthDate = dto.ApplicationUserCreateDTO.BirthDate;
			user.Email = dto.ApplicationUserCreateDTO.Email.Trim().ToLowerInvariant();
			user.PhoneNumber = dto.ApplicationUserCreateDTO.PhoneNumber;
			user.NormalizedUserName = user.Email;
			user.NormalizedEmail = user.Email.ToUpperInvariant();

			// Update the ApplicationUser without changing the password
			await _userManager.UpdateAsync(user);

			// Update member-specific fields
			existingMember.EducationalDegreeId = dto.EducationalDegreeId;
			

			// Commit the updates to the repository
			await _repository.UpdateAsync(existingMember);

			// Retrieve the updated member to return updated data
			var updatedMember = await _repository.GetByIdAsync(memberId);
			return MapToDto(updatedMember);
		}


		public override async Task<bool> DeleteAsync(string id)
		{
			var employee = await _userManager.FindByIdAsync(id);
			if (employee == null)
			{
				throw new Exception("User not found");
			}

			var employeeRoles = await _userManager.GetRolesAsync(employee);

			if (employeeRoles.Contains("Admin"))
			{
				throw new Exception("Admin cannot be deleted");
			}

			var result = await base.DeleteAsync(id);
			return result;
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
					Status = applicationUser.Status
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
					BirthDate = applicationUser.BirthDate
					
				},
				EducationalDegreeId = member.EducationalDegree?.Id ?? 0 
			};
		}

	}
}
