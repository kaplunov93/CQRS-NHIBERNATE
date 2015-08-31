using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate;
using FluentNHibernate.Mapping;

namespace DBProgram.Model
{
    public class Customer
    {
        public virtual int id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string number { get; set; }
        public virtual IList<Order> orders { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}\n",id,FirstName,LastName,number);
        }
    }

    public class CustomerMap:ClassMap<Customer>
    {
        public CustomerMap()
        {
            Id(x => x.id);
            Map(x => x.FirstName)
                .Length(20)
                .Not.Nullable();
            Map(x => x.LastName)
                .Length(20)
                .Not.Nullable();
            Map(x => x.number);
            HasMany(x=>x.orders);
        }
        

    }
    
}