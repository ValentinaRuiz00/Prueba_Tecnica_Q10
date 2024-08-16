using Model.Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IEmployeeLogic
    {
        List<EmployeerEntity> List();
        EmployeerEntity Get(int IdEmployeers);
        bool Add(EmployeerEntity oemployee);
        bool Update(EmployeerEntity oemployee);
        bool Delete(int IdEmployeers);
    }
}
