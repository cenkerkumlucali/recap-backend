using Core.Entities;

namespace Entities.Concrete
{
    public class Findeks:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FindeksScore { get; set; }
    }
}