using libAPI.Data;
using libAPI.DTOs;
using libAPI.Models;

namespace libAPI.Services.Abstract
{
	public interface IEducationalDegreeService:IService<EducationalDegree, EducationalDegreeDTO, libAPIContext,int>
	{
	}
}
