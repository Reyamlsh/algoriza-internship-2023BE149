using Core.Domain;
using Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class SettingController
    {
        private readonly IDiscountService _discountrepo;

        public SettingController(IDiscountService discountrepo)
        {
            _discountrepo = discountrepo;
        }

        
    }
}
