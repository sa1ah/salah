
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Kashkha.DAL
{
	public class Review:BaseEntity
	{
        public int CustomerId { get; set; }

		public string CustomerName {  get; set; }

		public string CustomerComment { get; set; }

		public int ProductId { get; set; }

		//[JsonIgnore]
		//public Product? Product { get; set; }=new Product();

	//	public DateTime? CreatedDate { get; set; }

    }
}
