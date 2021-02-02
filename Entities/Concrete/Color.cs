using System;
using System.Collections.Generic;
using System.Text;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Color:IEntity
    {
        public int CalorId { get; set; }
        public string CalorName { get; set; }
    }
}
