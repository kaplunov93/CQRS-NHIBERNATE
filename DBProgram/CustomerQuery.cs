using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBProgram.Model;
using NHibernate;

namespace DBProgram
{
    public static class CustomerQuery
    {
        public static Customer FindById(int id)
        {
            Customer customer=null;
            using (ISession session = SessionFactory.GetFactory().OpenSession())
            {
                var query = session.CreateQuery("from Customer where id= :ID");
                query.SetParameter("ID", id);
                if(query.List<Customer>().Count>0)
                    customer =query.List<Customer>().First();
            }
            return customer;
        }

        public static IList<Customer> FindByFirstName(string name)
        {
            IList<Customer> customer = null;
            using (ISession session = SessionFactory.GetFactory().OpenSession())
            {
                var query = session.CreateQuery("from Customer where FirstName= :Name");
                query.SetParameter("Name", name);
                customer = query.List<Customer>();
            }
            return customer;
        }

        public static IList<Customer> FindByLastName(string name)
        {
            IList<Customer> customer = null;
            using (ISession session = SessionFactory.GetFactory().OpenSession())
            {
                var query = session.CreateQuery("from Customer where LastName= :Name");
                query.SetParameter("Name", name);
                customer = query.List<Customer>();
            }
            return customer;
        }

        public static IList<Customer> FindByNumber(string number)
        {
            IList<Customer> customer = null;
            using (ISession session = SessionFactory.GetFactory().OpenSession())
            {
                var query = session.CreateQuery("from Customer where number= :number");
                query.SetParameter("number", number);
                customer = query.List<Customer>();
            }
            return customer;
        }
    }
}
