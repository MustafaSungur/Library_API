using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;
using System.Threading.Tasks;

namespace libAPI.Services.Concrete
{
	public class EmployeeManager : GenericManager<Employee, EmployeeCreateDTO, EmployeeReadDTO, libAPIContext, string>, IEmployeeService
	{
		private readonly IAddressService _addressService;

		public EmployeeManager(
			IEmployeeRepository repository,
			IAddressService addressService) : base(repository)
		{
			_addressService = addressService;
		}

		public override async Task<EmployeeReadDTO> AddAsync(EmployeeCreateDTO dto)
		{
			var addressDto =await _addressService.AddAsync(dto.ApplicationUserCreateDTO.Address);
			var entity = new Employee
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
					Status=true,
					RegisterDate=DateTime.Now,
					
				},
				
				TitleId = dto.TitleId,
				DepartmentId = dto.DepartmentId,
				Salary = dto.Salary,
				ShiftId = dto.ShiftId,
			};

			var result = await _repository.AddAsync(entity);

			var newEmployee = await _repository.GetByIdAsync(result.Id);

			return MapToDto(newEmployee);
		}

		public override EmployeeReadDTO MapToDto(Employee entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException(nameof(entity));
			}

			var applicationUser = entity.ApplicationUser;
			var address = applicationUser?.Address;

			return new EmployeeReadDTO
			{
				Id = entity.Id,
				ApplicationUserReadDTO = applicationUser == null ? null : new ApplicationUserReadDTO
				{
					Id = applicationUser.Id,
					FirstName = applicationUser.FirstName,
					LastName = applicationUser.LastName,
					Gender = new GenreReadDTO { Id = applicationUser.GenderId, Name = applicationUser.Gender.Name },
					Address = address == null ? null : new AddressReadDTO
					{
						Id = address.Id,
						City = new AddressCityReadDTO {Id=address.City.Id, Name=address.City.Name},
						Country = new AddressCountryReadDTO { Id = address.Country.Id,Name=address.Country.Name},
						ClearAddress = address.ClearAddress
					},
					BirthDate = applicationUser.BirthDate,
					RegisterDate = applicationUser.RegisterDate,
					Status = applicationUser.Status,
					PhotoUrl = applicationUser.PhotoUrl
				},
				Title = entity.Title == null ? null : new EmployeeTitleReadDTO { Id = entity.Title.Id, Name = entity.Title.Name },
				Department = entity.Department == null ? null : new DepartmentReadDTO { Id = entity.Department.Id, Name = entity.Department.Name },
				Salary = entity.Salary,
				Shift = entity.Shift == null ? null : new ShiftReadDTO { Id = entity.Shift.Id, Name = entity.Shift.Name }
			};
		}


		public override Employee MapToEntity(EmployeeCreateDTO dto)
		{
			return new Employee
			{
				ApplicationUser = new ApplicationUser
				{
					FirstName = dto.ApplicationUserCreateDTO.FirstName,
					LastName = dto.ApplicationUserCreateDTO.LastName,
					GenderId = dto.ApplicationUserCreateDTO.GenderId,
					Address = new Address
					{
						AddressCityId = dto.ApplicationUserCreateDTO.Address.AddressCityId,
						AddressCountryId = dto.ApplicationUserCreateDTO.Address.AddressCountryId,
						ClearAddress = dto.ApplicationUserCreateDTO.Address.ClearAddress,
					},
					BirthDate = dto.ApplicationUserCreateDTO.BirthDate,
					PhotoUrl = dto.ApplicationUserCreateDTO.PhotoUrl,
					Password = dto.ApplicationUserCreateDTO.Password
				},
				TitleId = dto.TitleId,
				DepartmentId = dto.DepartmentId,
				Salary = dto.Salary,
				ShiftId = dto.ShiftId,
			};
		}
	}
}
