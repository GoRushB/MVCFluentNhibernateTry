using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace real_MVC_fluent_nhibernate_try.Models
{
    public class Store
    {
        public virtual int StoreId { get; protected set; }
        public virtual string Name { get; set; }
        public virtual string StoreArtUrl { get; set; }
        public virtual IList<Employee> Employees { get; set; }
        public virtual IList<Product> Products { get; set; }
        public Store()
        {
            Employees = new List<Employee>();
            Products = new List<Product>();
        }
        public virtual void AddEmployee(Employee employee)
        {
            employee.Store = this;
            Employees.Add(employee);
        }
        public virtual void DelEmployee(Employee employee)
        {
            employee.Store = null;
            Employees.Remove(employee);
        }
        public virtual void AddProduct(Product product)
        {
            product.Stores.Add(this);
            Products.Add(product);
        }
        public virtual void DelProduct(Product product)
        {
            product.Stores.Remove(this);
            Products.Remove(product);
        }
    }
}