
using Sat.Recruiment.Model;
using System.Collections.Generic;

namespace Sat.Recruiment.IData
{
    public interface IContext
    {
        List<User> getUsers();
    }
}
