
using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace Entities.Concrete
{
    public class Customer : IEntity
    {
        [Key]
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public int FindeksScore { get; set; }
    }
}
