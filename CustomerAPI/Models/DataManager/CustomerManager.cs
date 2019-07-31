using CustomerAPI.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Models.DataManager
{
    public class CustomerManager : IDataRepository<Customer>
    {
        readonly CustomerDBContext _customerContext;
        public CustomerManager(CustomerDBContext context)
        {
            _customerContext = context;
        }
        public void Add(Customer entity)
        {
            _customerContext.Customer.Add(entity);
            _customerContext.SaveChanges();
        }

        public void Delete(Customer entity)
        {
            _customerContext.Customer.Remove(entity);
            _customerContext.SaveChanges();
        }

        public Customer Get(long id)
        {
            return _customerContext.Customer
                  .FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customerContext.Customer.ToList();
        }

        public void Update(Customer dbEntity, Customer entity)
        {

            dbEntity.FirstName = entity.FirstName;
            dbEntity.LastName = entity.LastName;
            dbEntity.Phone = entity.Phone;

            _customerContext.SaveChanges();
        }
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await Task.FromResult(_customerContext.Customer.ToList());
        }
        public async Task<Customer> GetAsync(long id)
        {
            return await Task.FromResult(_customerContext.Customer
               .FirstOrDefault(c => c.Id == id));
        }

        public async Task AddAsync(Customer entity)
        {
            _customerContext.Customer.Add(entity);
            await _customerContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer dbEntity, Customer entity)
        {
            dbEntity.FirstName = entity.FirstName;
            dbEntity.LastName = entity.LastName;
            dbEntity.Phone = entity.Phone;

            await _customerContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Customer entity)
        {
            _customerContext.Customer.Remove(entity);
            await _customerContext.SaveChangesAsync();
        }



    }
}
