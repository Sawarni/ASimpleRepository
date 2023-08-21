using ASimpleRepository.Interface;
using ASimpleRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASimpleRepository.SampleUse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dbConnection = Effort.DbConnectionFactory.CreateTransient();
            int customerId = 1;

            var entityContext = new EntityContext(dbConnection);

            AddOrUpdateCustomer(entityContext, new Customer { CustomerID = 1, Name = "Sawarni Manu" });
            GetCustomer(entityContext, customerId);
            AddOrUpdateCustomer(entityContext, new Customer { CustomerID = 1, Name = "Mohini Manu" });
            GetCustomer(entityContext, customerId);
            AddOrUpdateCustomer(entityContext, new Customer { CustomerID = 2, Name = "Sawarni Manu" });
            GetCustomer(entityContext, 2);

            GetAllCustomers(entityContext);

            Console.ReadLine();


        }

        private static void GetAllCustomers(EntityContext entityContext)
        {
            IUnitOfWork unitOfWork = new UnitOfWork(entityContext);


            var customerRepository = unitOfWork.Repository<Customer>();

            var customers = customerRepository.GetAll();
            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.CustomerID} - {customer.Name}");
            }
        }

        private static void GetCustomer(EntityContext entityContext, int customerId)
        {
            IUnitOfWork unitOfWork = new UnitOfWork(entityContext);


            var customerRepository = unitOfWork.Repository<Customer>();

            var customer2 = customerRepository.Get(x => x.CustomerID == customerId);

            Console.WriteLine($"{customer2.CustomerID} - {customer2.Name}");

        }

       

        private static void AddOrUpdateCustomer(EntityContext entityContext, Customer customer)
        {

            IUnitOfWork unitOfWork = new UnitOfWork(entityContext);
            IRepository<Customer> customerRepository = unitOfWork.Repository<Customer>();
            customerRepository.AddOrUpdate(customer);
            unitOfWork.SaveChanges();
        }
    }
}
