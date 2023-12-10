using Core.Domain;
using Core.Repository;
using Core.Service;
using Repository;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDoctorService _repo;

        public HomeController(IDoctorService repo)
        {
            _repo = repo;
        }

        public IEnumerable<Doctor> Index()
        {
            return _repo.GetAll();
        }
    }
}
