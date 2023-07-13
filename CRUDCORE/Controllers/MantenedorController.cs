using Microsoft.AspNetCore.Mvc;
using CRUDCORE.Data;
using CRUDCORE.Models;

namespace CRUDCORE.Controllers
{
    public class MantenedorController : Controller
    {
        ContactData _ContactData = new ContactData();

        public IActionResult Listar()
        {
            var oLista = _ContactData.Listar();  
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ContactModel ocontacto)
        
        {
            if (!ModelState.IsValid) return View();
            var rta = _ContactData.Guardar(ocontacto);
            if(rta)
            return RedirectToAction("Listar");
            else 
                return View();
        }

        public IActionResult Editar(int IdContacto)
        {
            var ocontacto = _ContactData.Obtener(IdContacto);
            return View(ocontacto);
        }
        [HttpPost]
        public IActionResult Editar(ContactModel ocontacto)
        {
            if (!ModelState.IsValid) return View();
            var rta = _ContactData.Editar(ocontacto);
            if (rta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int IdContacto)
        {
            var ocontacto = _ContactData.Obtener(IdContacto);
            return View(ocontacto);
        }
        [HttpPost]
        public IActionResult Eliminar(ContactModel ocontacto)
        {
            var rta = _ContactData.Eliminar(ocontacto.IdContacto);
            if (rta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
