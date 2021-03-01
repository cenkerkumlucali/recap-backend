using Core.Entities;

namespace Entities.Concrete
{
    public class CarDto:IEntity
    {
        public int ColorId { get; set; }
        public string ColorName { get; set; }
    }
}
