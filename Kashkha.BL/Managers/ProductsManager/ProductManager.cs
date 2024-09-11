using Kashkha.API;
using Kashkha.DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.BL
{
	public class ProductManager : IProductManager
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IConfiguration _configuration;

		public ProductManager(IUnitOfWork unitOfWork,IConfiguration configuration)
		{
			_unitOfWork = unitOfWork;
			_configuration = configuration;
		}
		public void Add(AddProductDto productDto)
		{
			var imageUrl = DocumentSettings.UploadFile(productDto.Image);
			
			_unitOfWork._ProductRepository.Add(new Product()
			{
				Name = productDto.ProductName,
				Description = productDto.Description,
				Price = productDto.Price,
				Quantity = productDto.Quantity,
				PictureUrl= imageUrl ?? string.Empty,
				CategoryId=productDto.CategoryId
			});
			_unitOfWork.Complete();
		}

		public void Delete(Product product)
		{
		

			_unitOfWork._ProductRepository.Delete(product);
			var result = _unitOfWork.Complete();
			if (result > 0)
			{
				if (!string.IsNullOrEmpty(product.PictureUrl))
					DocumentSettings.DeleteFile(product.PictureUrl);
			}
		}
		public Product Get(int id)
		{
			var product = _unitOfWork._ProductRepository.GetFirstOrDefault(id);
			product.PictureUrl = _configuration["ApiBaseUrl"] + product.PictureUrl;
			return product;
		}
		//public GetProductDto Get(int id)
		//{
		//	var product = _unitOfWork._ProductRepository.GetFirstOrDefault(id);

		//	return (new GetProductDto()
		//	{
		//		ProductName=product.Name,
		//		Description=product.Description,
		//		Price=product.Price,
		//		Quantity=product.Quantity,
		//		ProductRewiews=product.Rewiews,
		//		Image=product.PictureUrl,
		//		CategoryId=product.CategoryId,
		//	});
		//}

		public List<GetProductDto> GetAll()
		{
			var product = _unitOfWork._ProductRepository.GetAllWithCategory();
			return product.Select(p => new GetProductDto() {
				Id= p.Id,
				ProductName=p.Name ,
				Description=p.Description ,
				Price=p.Price,
				Quantity=p.Quantity,
				CategoryId=p.CategoryId,
				Image= _configuration["ApiBaseUrl"] + p.PictureUrl,
				CategoryName=p.Category!.Name,
				ProductRewiews= p.Rewiews
			}).ToList();
		}

		public List<GetProductDto> SearchProductByName(string name)
		{
		   return (List<GetProductDto>) _unitOfWork._ProductRepository.SearchProductByName(name);
		}

		public void Update(UpdateProductDto product)
		{
			var newProduct = _unitOfWork._ProductRepository.GetFirstOrDefault(product.Id);
			string oldImage="";
			newProduct!.Name = product.ProductName?? newProduct!.Name;
			newProduct!.Description = product.Description?? newProduct!.Description;
			newProduct!.Price = product.Price ?? newProduct!.Price;
			newProduct!.Quantity = product.Quantity ?? newProduct!.Quantity;
			newProduct!.CategoryId = product.CategoryId ?? newProduct!.CategoryId;
			if(product.Image !=null)
			{
				oldImage = newProduct.PictureUrl;
				newProduct.PictureUrl = DocumentSettings.UploadFile(product.Image);
			}

			var result = _unitOfWork.Complete();

			if (result > 0)
				DocumentSettings.DeleteFile(oldImage);


		}

		public bool isFound(int id)
		{
			return _unitOfWork._ProductRepository.isFound(id);
		}

	}
}
