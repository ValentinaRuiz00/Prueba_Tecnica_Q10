using Model.Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class EmployeeLogic : IEmployeeLogic
    {
        private readonly IEmployerRepository _EmployeeRepository;

        //Inyeccion de dependencias
        public EmployeeLogic(IEmployerRepository EmployeerRepository)
        {
            this._EmployeeRepository = EmployeerRepository;
        }

        public List<EmployeerEntity> List()
        {
            return _EmployeeRepository.List();
        }

        public EmployeerEntity Get(int IdEmployeers)
        {
            return _EmployeeRepository.Get(IdEmployeers);
        }

        public bool Add(EmployeerEntity oemployee)
        {
            return _EmployeeRepository.Add(oemployee);
        }

        public bool Update(EmployeerEntity oemployee)
        {
            return _EmployeeRepository.Update(oemployee);
        }
        public bool Delete(int IdEmployeers)
        {
            return _EmployeeRepository.Delete(IdEmployeers);
        }
    }
}

