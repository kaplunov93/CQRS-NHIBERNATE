using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cqrs;
using Cqrs.Commands;
using DBProgram.Model;
using NHibernate;

namespace DBProgram
{
    public interface ICommand:IMessage
    {

    }

    public class AddNewCustomer:ICommand
    {
        public AddNewCustomer(string FirstName,string LastName,string number="")
        {
            Customer customer = new Customer();
            customer.FirstName = FirstName;
            customer.LastName = LastName;
            customer.number = number;

            using (ISession session = SessionFactory.GetFactory().OpenSession())
            {
                session.Save(customer);
            }
        }
    }

    /// <summary>
    ///!!! Don't Work !!!
    /// </summary>
    public class DeleteCustomer:ICommand
    {
        public DeleteCustomer(int id)
        {
            Customer customer = CustomerQuery.FindById(id);
            using (ISession session = SessionFactory.GetFactory().OpenSession())
            {
                session.Delete(customer);
            }
        }
    }
}
