using libAPI.Data;
using libAPI.Data.Repositories.Abstract;
using libAPI.DTOs;
using libAPI.Models;
using libAPI.Services.Abstract;
using Microsoft.AspNetCore.Identity;


namespace libAPI.Services.Concrete
{
	public class EmployeeManager : GenericManager<Employee, EmployeeCreateDTO, EmployeeReadDTO, libAPIContext, string>, IEmployeeService
	{
		private readonly IAddressService _addressService;
		private readonly IEmployeeRepository _employeeRepository;

		private readonly UserManager<ApplicationUser> _userManager;
		public EmployeeManager(
			IEmployeeRepository repository,
			IAddressService addressService,UserManager<ApplicationUser> userManager) : base(repository)
		{
			_addressService = addressService;
			_userManager = userManager;
			_employeeRepository = repository;
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
			entity.ApplicationUser!.UserName = entity!.ApplicationUser!.Email;
			entity.ApplicationUser!.NormalizedUserName = entity.ApplicationUser!.Email!.Trim().ToLowerInvariant();
			entity.ApplicationUser!.Email = entity.ApplicationUser!.Email.Trim().ToLowerInvariant();
			entity.ApplicationUser!.NormalizedEmail = entity.ApplicationUser!.Email.ToUpperInvariant();
			_userManager.CreateAsync(entity.ApplicationUser!, entity.ApplicationUser!.Password).Wait();
			_userManager.AddToRoleAsync(entity.ApplicationUser, "Worker").Wait();


			var result = await _repository.AddAsync(entity);

			var newEmployee = await _repository.GetByIdAsync(result.Id);

			return MapToDto(newEmployee!);
		}

		public async Task<EmployeeReadDTO> UpdateAsync(string employeeId, EmployeeCreateDTO dto)
		{
			// Retrieve the existing employee
			var existingEmployee = await _repository.GetByIdAsync(employeeId);
			if (existingEmployee == null)
			{
				throw new Exception("Employee not found");
			}

			// Update the address if necessary
			var updatedAddressDto = await _addressService.UpdateAsync(dto.ApplicationUserCreateDTO.Address);

			// Update the application user details
			var user = existingEmployee.ApplicationUser;
			if (user == null)
			{
				throw new Exception("Associated user not found");  // Ideally handle more gracefully
			}

			user.FirstName = dto.ApplicationUserCreateDTO.FirstName;
			user.LastName = dto.ApplicationUserCreateDTO.LastName;
			user.GenderId = dto.ApplicationUserCreateDTO.GenderId;
			user.AddressId = updatedAddressDto.Id; // Assuming address update returns updated DTO
			user.BirthDate = dto.ApplicationUserCreateDTO.BirthDate;
			user.Email = dto.ApplicationUserCreateDTO!.Email!.Trim().ToLowerInvariant();
			user.PhoneNumber = dto.ApplicationUserCreateDTO.PhoneNumber;
			user.NormalizedUserName = user.Email;
			user.NormalizedEmail = user.Email.ToUpperInvariant();

			// Update the ApplicationUser without changing the password
			await _userManager.UpdateAsync(user);

			// Update employee-specific fields
			existingEmployee.TitleId = dto.TitleId;
			existingEmployee.DepartmentId = dto.DepartmentId;
			existingEmployee.Salary = dto.Salary;
			existingEmployee.ShiftId = dto.ShiftId;

			// Commit the updates to the repository
			await _repository.UpdateAsync(existingEmployee);

			// Retrieve the updated employee to return updated data
			var updatedEmployee = await _repository.GetByIdAsync(employeeId);
			return MapToDto(updatedEmployee!);
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

			var result =await _repository.DeleteAsync(id);
			return result;
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
					Id = applicationUser!.Id!,
					FirstName = applicationUser!.FirstName!,
					LastName = applicationUser!.LastName!,
					Gender = new GenreReadDTO { Id = applicationUser.GenderId, Name = applicationUser.Gender.Name },
					Address = address == null ? null : new AddressReadDTO
					{
						Id = address.Id,
						City = new AddressCityReadDTO {Id=address.City.Id, Name=address.City.Name},
						Country = new AddressCountryReadDTO { Id = address.Country.Id,Name=address.Country.Name},
						ClearAddress = address.ClearAddress
					},
					BirthDate = applicationUser!.BirthDate!,
					RegisterDate = applicationUser!.RegisterDate!,
					Status = applicationUser!.Status!
				},
				Title = entity.Title == null ? null : new EmployeeTitleReadDTO { Id = entity.Title.Id, Name = entity.Title.Name },
				Department = entity.Department == null ? null : new DepartmentReadDTO { Id = entity.Department.Id, Name = entity.Department.Name },
				Salary = entity.Salary,
				Shift = entity!.Shift! == null ? null : new ShiftReadDTO { Id = entity.Shift!.Id!, Name = entity.Shift!.Name! }
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
