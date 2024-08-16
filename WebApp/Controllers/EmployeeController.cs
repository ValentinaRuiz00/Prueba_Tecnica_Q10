using Logic;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using System.Collections.Generic;

namespace WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeLogic _employeeLogic;

        public EmployeeController(IEmployeeLogic employeeLogic)
        {
            _employeeLogic = employeeLogic;
        }

        //Método que devuelve el index
        public IActionResult Index()
        {
            return View();
        }

        //Método para mostrar la lista de empleados
        [HttpGet]
        public JsonResult GetEmployees()
        {
            return Json(_employeeLogic.List());
        }

        //Método que recibe un objeto y lo guarda en la base de datos
        [HttpPost]
        public JsonResult Add(EmployeerEntity oEmployee)
        {
            return Json(_employeeLogic.Add(oEmployee));
        }

        //Método que devulve la vista
        public IActionResult Update(int IdEmployeers)
        {

            var oEmployee = _employeeLogic.Get(IdEmployeers);
            return View(oEmployee);
        }

        //Método para editar un empleado
        [HttpPost]
        public JsonResult Update(EmployeerEntity oEmployee)
        {
            return Json(_employeeLogic.Update(oEmployee));
        }

        //Método para eliminar empleado

        [HttpPost]
        public JsonResult Delete(int IdEmployeers)
        {
            return Json(_employeeLogic.Get(IdEmployeers));
        }

    }
}
