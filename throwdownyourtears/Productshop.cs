using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace throwdownyourtears
{
    public partial class Productshop
    {
        public int Id { get; set; }

        public int? Productid { get; set; }

        public int? Shopid { get; set; }

        public virtual Product? Product { get; set; }

        public virtual Shop? Shop { get; set; }

    }
}
