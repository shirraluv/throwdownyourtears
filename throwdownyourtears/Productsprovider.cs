using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace throwdownyourtears
{
    public partial class Productsprovider
    {

        public int Id { get; set; }

        public int? ProductsId { get; set; }

        public int? ProviderId { get; set; }

        public virtual Product? Products { get; set; }

        public virtual Provider? Provider { get; set; }
    }

}

