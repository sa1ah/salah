using System;
using System.Linq;
using System.Text;


namespace Kashkha.DAL
{
	public class Shop : BaseEntity
    {

        public string Name { get; set; }

        public virtual Address Address { get; set; }
    }

}
