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
    public class CustomerAccountProccesService : ICustomerAccountProcessService
    {
        private readonly ICustomerAccountProcessDal _customerAccountProcessDal;

        public CustomerAccountProccesService(ICustomerAccountProcessDal customerAccountProcessDal)
        {
            _customerAccountProcessDal = customerAccountProcessDal;
        }

        public void TDelete(CustomerAccountProcess t)
        {
            _customerAccountProcessDal.Delete(t);
        }

        public CustomerAccountProcess TGetById(int id)
        {
            return _customerAccountProcessDal.GetById(id);
        }

        public List<CustomerAccountProcess> TGetList()
        {
            return _customerAccountProcessDal.GetList();
        }

        public void TInsert(CustomerAccountProcess t)
        {
            _customerAccountProcessDal.Insert(t);
        }

        public void TUpdate(CustomerAccountProcess t)
        {
            _customerAccountProcessDal.Update(t);
        }
    }
}
