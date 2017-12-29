using GraphQL.Types;

namespace Samples.Schemas.Orders
{
    public class OrderActionInputType : InputObjectGraphType
    {
        public OrderActionInputType()
        {
            Name = "OrderActionInput";
            Field<NonNullGraphType<StringGraphType>>("orderId", "Id of the order");
        }
    }
}
