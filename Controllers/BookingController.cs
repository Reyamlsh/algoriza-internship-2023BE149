using Core.Domain;
using Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BookingController
    {
        private readonly IAppointmentService _appointrepo;

        public BookingController(IAppointmentService appointrepo)
        {
            _appointrepo = appointrepo;
        }

       
    }
}
