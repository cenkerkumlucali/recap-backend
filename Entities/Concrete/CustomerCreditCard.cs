using Core.Entities;

namespace Entities.Concrete
{
    public class CustomerCreditCard:IEntity
    {
        public int CustomerId { get; set; }
        public int CardId { get; set; }  
    }
}