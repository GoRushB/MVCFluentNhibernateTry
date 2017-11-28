using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace real_MVC_fluent_nhibernate_try.Models
{
    public class Employee
    {
        public virtual int EmployeeId { get; protected set; }
        public virtual string Name { get; set; }
        public virtual string EmployeeArtUrl { get; set; }
        public virtual Store Store { get; set; }
    }
}