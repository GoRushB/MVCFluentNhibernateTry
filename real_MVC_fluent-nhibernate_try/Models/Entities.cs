namespace real_MVC_fluent_nhibernate_try.Models
{
    public class Entities
    {
        private void AddProductsToStore(Store store, params Product[] products)
        {
            foreach (var product in products)
                store.AddProduct(product);
        }

        private void AddEmployeesToStore(Store store, params Employee[] employees)
        {
            foreach (var employee in employees)
                store.AddEmployee(employee);
        }

        public void Project()
        {
            Store
                barginBasin = new Store {Name = "Bargin Basin", StoreArtUrl = "/Content/Images/photo1.png"},
                superMart = new Store {Name = "SuperMart", StoreArtUrl = "/Content/Images/photo1.png"};

            Product
                potatoes = new Product {Name = "Potatoes", Price = 3.60m, ProductArtUrl = "/Content/Images/photo2.png"},
                fish = new Product {Name = "Fish", Price = 4.49m, ProductArtUrl = "/Content/Images/photo2.png"},
                milk = new Product {Name = "Milk", Price = 0.79m, ProductArtUrl = "/Content/Images/photo2.png"},
                bread = new Product {Name = "Bread", Price = 1.29m, ProductArtUrl = "/Content/Images/photo2.png"},
                cheese = new Product {Name = "Cheese", Price = 2.10m, ProductArtUrl = "/Content/Images/photo2.png"},
                waffles = new Product {Name = "Waffles", Price = 2.41m, ProductArtUrl = "/Content/Images/photo2.png"};

            Employee
                daisy = new Employee {Name = "Daisy Harrison", EmployeeArtUrl = "/Content/Images/photo3.png"},
                jack = new Employee {Name = "Jack Torrance", EmployeeArtUrl = "/Content/Images/photo3.png"},
                sue = new Employee {Name = "Sue Walkters", EmployeeArtUrl = "/Content/Images/photo3.png"},
                bill = new Employee {Name = "Bill Taft", EmployeeArtUrl = "/Content/Images/photo3.png"},
                joan = new Employee {Name = "Joan Pope", EmployeeArtUrl = "/Content/Images/photo3.png"};

            AddEmployeesToStore(barginBasin, daisy, jack, sue);
            AddEmployeesToStore(superMart, bill, joan);

            AddProductsToStore(barginBasin, potatoes, fish, milk, bread, cheese);
            AddProductsToStore(superMart, bread, cheese, waffles);


            using (var session = NHibernateHelper.OpenSession())
            {
                session.SaveOrUpdate(barginBasin);
                session.SaveOrUpdate(superMart);
            }
        }
    }
}