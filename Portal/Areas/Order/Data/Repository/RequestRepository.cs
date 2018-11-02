using Portal.Areas.Order.Data.Interfaces;
using Portal.Areas.Order.Data.Model;
using Portal.Data; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Portal.Areas.Order.Data.Repository
{
    public class RequestRepository : Repository<Request>, IRequestRepository
    {
        public RequestRepository(ApplicationDbContext context) : base(context)
        {
        }
        //public void CreateNewOrder(Request request, <T> entity)
        //{
        //    //Set up our transactional boundary.
        //    using (TransactionScope ts = new TransactionScope())
        //    {
        //        IRequestRepository orderRepos = GetOrderRespository();
        //        this.Create(request);
        //        orderRepos.SaveNew(order);
        //        customer.Status = CustomerStatus.OrderPlaced;

        //        ICustomerRepository customerRepository = GetCustomerRepository();
        //        customerRepository.Save(customer)
        //      ts.Commit();
        //    }
        //}
    }
}
