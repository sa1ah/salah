using Kashkha.API;
using Kashkha.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.BL
{
	public interface IReviewManager
	{
		void Add(Review review);
		void Delete(Review review);
		void Update(ReviewUpdateDto reviewDto);
		Review GetById(int id);
	}
}
