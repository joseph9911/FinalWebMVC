using System.Web.Mvc;
using DoFactory.Repositorio;

namespace DoFactory.Areas.Factoria.Controllers
{

    [OutputCache(Duration = 0)]
    public class BaseController<T> : Controller where T: class
    {
        protected IRepositorio<T> _repository;
        // GET: Factoria/Base
        public BaseController()
        {
            _repository = new RepositorioBase<T>();
        }
    }
}