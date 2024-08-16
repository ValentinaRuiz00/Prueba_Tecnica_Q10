using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IEmployerRepository
    {

            List<EmployeerEntity> List();
            EmployeerEntity Get(int IdEmployeers);
            bool Add(EmployeerEntity oemployee);
            bool Update(EmployeerEntity oemployee);
            bool Delete(int IdEmployeers);
        
    }
}
