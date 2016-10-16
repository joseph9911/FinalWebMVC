using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DoFactory.Modelo;

namespace DoFactory.Areas.Factoria.Controllers
{
    public class ClienteController : BaseController<Customer>
    {
        public ActionResult Indice()
        {
            return View(_repository.PaginatedList((x => x.Id), 1, 15));
        }

        public ActionResult List(int? page, int? size)
        {
            if (!page.HasValue || !size.HasValue)
            {
                page = 1;
                size = 15;
            }
            return PartialView("_List", _repository.PaginatedList((x => x.Id), page.Value, size.Value));
        }

        public ActionResult Crear()
        {
            return PartialView("_Crear");
        }

        [HttpPost]
        public ActionResult Crear(Customer cliente)
        {
            if (!ModelState.IsValid) return PartialView("_Crear", cliente);
           
            _repository.Add(cliente);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        public ActionResult Editar(int id)
        {
            var cliente = _repository.GetById(x => x.Id == id);
            if (cliente == null) return RedirectToAction("Indice");
            return PartialView("_Editar",cliente);
        }

        [HttpPost]
        public ActionResult Editar(Customer cliente)
        {
            if (!ModelState.IsValid) return PartialView("_Editar", cliente);
            _repository.Update(cliente);
            return RedirectToAction("Indice");
        }

        public ActionResult Eliminar(int id)
        {
            var cliente = _repository.GetById(x => x.Id == id);
            if (cliente == null) return RedirectToAction("Indice");
            return PartialView("_Elminiar", cliente);            
        }

        [HttpPost]
        public ActionResult Eliminar(Customer cliente)
        {
            cliente = _repository.GetById(x => x.Id == cliente.Id);
            _repository.Delete(cliente);
            return RedirectToAction("Indice");
        }

        public ActionResult Detalles(int id)
        {
            var cliente = _repository.GetById(x => x.Id == id);
            if (cliente == null) return RedirectToAction("Indice");
            return PartialView("_Detalles",cliente);
        }

        public int PageSize(int pageSize)
        {
            if (pageSize <= 0) return 0;
            var totalRecords = _repository.GetList().Count;
            return totalRecords % pageSize > 0 ? (totalRecords / pageSize) + 1 : totalRecords / pageSize;
        }   
    }
}