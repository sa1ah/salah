using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Kashkha.DAL
{ 
	public class Product : BaseEntity
    {
 
		public string Name { get; set; }
        public string? Description { get; set; }
        public string? PictureUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int? CategoryId { get; set; }
         public Category? Category { get; set; }
		//shop owner
		//public int UserId { get; set; }
		//public User? user { get; set; }

		public ICollection<Review>? Rewiews { get; set; } = new List<Review>();


	}
}
