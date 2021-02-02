using System;
using System.Collections.Generic;
using System.Text;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Category:IEntity
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }
}
