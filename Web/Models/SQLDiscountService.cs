using Core.Domain;
using Core.Service;
using Repository;

namespace Web.Models
{
    public class SQLDiscountService : IDiscountService
    {
        private readonly ApplicationDbContext _context;

        public SQLDiscountService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool DeactivateDiscount(int ID)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Discount> GetAll()
        {
            throw new NotImplementedException();
        }

        public Discount GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Discount GetDiscountbyCode(string discountCode)
        {
            Discount discount = _context.Discounts.SingleOrDefault(x => x.code == discountCode);

            return discount;
        }

        public bool Insert(Discount entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Discount entity)
        {
            throw new NotImplementedException();
        }
    }
}
