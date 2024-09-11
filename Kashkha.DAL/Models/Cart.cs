
using Kashkha.DAL.Models;

namespace Kashkha.DAL
{
	public class Cart
	{

       public int Id { get; set; }
    public string UserId { get; set; } // Assuming you're using ASP.NET Core Identity
    public List<CartItem> Items { get; set; } = new();
    public decimal TotalPrice => Items.Sum(i => i.TotalPrice);

        public Cart(int id)
        {
            Id= id;
        }

    }
}
