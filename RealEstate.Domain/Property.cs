using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Domain
{
    public class Property
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Address { get; set; }
        public string? Description { get; set; } // For listing details

        // will be Using hardcoded for now
        public string? ImageUrl { get; set; }

        public ICollection<Favorite>? Favorites { get; set; }
    }
}
