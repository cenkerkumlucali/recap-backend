using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
   public class FindeksDetailDto
    {
        public int FindeksId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int FindeksScore { get; set; }
    }
}
