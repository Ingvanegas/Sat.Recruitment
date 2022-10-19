
using Sat.Recruiment.IBusiness.DTO;
using System.IO;
using System.Threading.Tasks;

namespace Sat.Recruiment.IBusiness
{
    public interface IUserBusiness
    {
        Task<IResultDto> CreateUser(IUserDto newUser);

        void ValidateErrors(IUserDto newUser, ref string errors);
    }
}
