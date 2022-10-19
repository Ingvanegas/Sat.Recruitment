using Sat.Recruiment.Business.DTO;
using Sat.Recruiment.IBusiness;
using Sat.Recruiment.IBusiness.DTO;
using System.Diagnostics;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Sat.Recruiment.IBusiness.Enum;
using Sat.Recruiment.Data;
using Sat.Recruiment.Model;

namespace Sat.Recruiment.Business
{
    public class UserBusiness : IUserBusiness
    {
        public async Task<IResultDto> CreateUser(IUserDto newUser)
        {
            var errors = "";

            ValidateErrors(newUser, ref errors);

            if (!string.IsNullOrEmpty(errors))
                return new ResultDto()
                {
                    IsSuccess = false,
                    Errors = errors
                };

            if (newUser.UserType == UserType.Normal)
            {
                if (newUser.Money > 100)
                {
                    decimal percentage = 0.12m;
                    //If new user is normal and has more than USD100
                    var gif = newUser.Money * percentage;
                    newUser.Money = newUser.Money + gif;
                }

                if (newUser.Money < 100 && newUser.Money > 10)
                {
                    var percentage = 0.8m;
                    var gif = newUser.Money * percentage;
                    newUser.Money = newUser.Money + gif;
                }
            }

            if (newUser.UserType == UserType.SuperUser && newUser.Money > 100m)
            {
                var percentage = Convert.ToDecimal(0.20);
                var gif = newUser.Money * percentage;
                newUser.Money = newUser.Money + gif;
            }

            if (newUser.UserType == UserType.Premium && newUser.Money > 100m)
            {
                var gif = newUser.Money * 2;
                newUser.Money = newUser.Money + gif;
            }

            //Normalize email
            var aux = newUser.Email.Split('@', StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            newUser.Email = string.Join("@", new string[] { aux[0], aux[1] });

            List<User> _users = new Context().getUsers();

            try
            {
                bool isDuplicated = false;
                foreach (var user in _users)
                {

                    isDuplicated = (user.Email == newUser.Email || user.Phone == newUser.Phone);

                    if (!isDuplicated && (user.Name == newUser.Name && user.Address == newUser.Address))
                        throw new Exception("User is duplicated");
                }

                if (!isDuplicated)
                {
                    Debug.WriteLine("User Created");

                    return new ResultDto()
                    {
                        IsSuccess = true,
                        Result = "User Created"
                    };
                }
                else
                {
                    Debug.WriteLine("The user is duplicated");

                    return new ResultDto()
                    {
                        IsSuccess = false,
                        Errors = "The user is duplicated"
                    };
                }
            }
            catch
            {
                Debug.WriteLine("The user is duplicated");
                return new ResultDto()
                {
                    IsSuccess = false,
                    Errors = "The user is duplicated"
                };
            }
        }       

        public void ValidateErrors(IUserDto newUser, ref string errors)
        {
            if (newUser.Name == null)
                //Validate if Name is null
                errors = "The name is required";
            if (newUser.Email == null)
                //Validate if Email is null
                errors = $"{errors} The email is required";
            if (newUser.Address == null)
                //Validate if Address is null
                errors = $"{errors} The address is required";
            if (newUser.Phone == null)
                //Validate if Phone is null
                errors = $"{errors} The phone is required";
        }
    }
}
