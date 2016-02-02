using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFTPracticum.Models
{
    public class Dish
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public bool AllowMultiple { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Code, Description);
        }
    }
}
