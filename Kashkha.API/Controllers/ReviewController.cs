using Kashkha.BL;
using Kashkha.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kashkha.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReviewController : ControllerBase
	{
		private readonly IReviewManager _reviewManager;

		public ReviewController(IReviewManager reviewManager)
        {
			_reviewManager = reviewManager;
		}

		[HttpPost]
		public ActionResult PostReview([FromForm]Review review)
		{
			if (review is null)
			{
				return BadRequest("The comment must not be empty");
			}
			_reviewManager.Add(review);
			return Ok(review);
		}

		[HttpDelete("{id:int}")]
		public ActionResult DeleteReview([FromRoute] int id)
		{

			var review = _reviewManager.GetById(id);
			if (review is null)
			{
				return NotFound("No review found");
			}
			_reviewManager.Delete(review);
			return NoContent();
		}

		[HttpPatch]
		public ActionResult UpdateReview([FromForm] ReviewUpdateDto reviewDto)
		{
			var review = _reviewManager.GetById(reviewDto.Id);
			if (review is null)
			{
				return NotFound("No review found");
			}
			_reviewManager.Update(reviewDto);
			return NoContent();
		}


	}
}
