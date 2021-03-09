using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTest.Models
{
    internal class Customer
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthdate { get; set; }
        public string PhoneNum { get; set; }

    }

    internal class Group
    {
        public string Name { get; set; }
        public ICollection<Customer> Customers { get; set;}
    }
}
