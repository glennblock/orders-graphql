using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Samples.Schemas.Orders
{
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType()
        {
            Field(c => c.Id)
                .Description("Customer Id");
            Field(c => c.Name)
                .Description("Customer Name");
        }
    }
}
