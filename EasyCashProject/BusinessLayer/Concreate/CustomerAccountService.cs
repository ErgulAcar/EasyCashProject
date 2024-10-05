using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class CustomerAccountService : ICustomerAccountService
    {
        private readonly ICustomerAccountDal _customerAccountDal;

        public CustomerAccountService(ICustomerAccountDal customerAccountDal)
        {
            _customerAccountDal = customerAccountDal;
        }

        public void TDelete(CustomerAccount t)
        {
            _customerAccountDal.Delete(t);
        }

        public CustomerAccount TGetById(int id)
        {
            return _customerAccountDal.GetById(id);
        }

        public List<CustomerAccount> TGetList()
        {
            return _customerAccountDal.GetList();
        }

        public void TInsert(CustomerAccount t)
        {
           _customerAccountDal.Insert(t);
        }

        public void TUpdate(CustomerAccount t)
        {
            _customerAccountDal.Update(t);
        }
    }
}
