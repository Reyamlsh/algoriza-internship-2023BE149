using Core.Domain;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DiscountService : BaseEntityService<Discount>, IDiscountService
    {
        public DiscountService(IRepository<Discount> repository) : base(repository)
        {
        }

        public bool DeactivateDiscount(int ID)
        {
            Discount disc = _repository.GetByID(ID);
            disc.activationStatus = false;

            if (!disc.activationStatus)
                return true;
            return false;
        }

        public Discount GetDiscountbyCode(string code)
        {
            throw new NotImplementedException();
        }
    }
}
