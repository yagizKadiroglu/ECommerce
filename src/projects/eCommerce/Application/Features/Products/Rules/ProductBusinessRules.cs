using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Rules
{
    public class ProductBusinessRules
    {
        private readonly IProductRepository _productRepository;

        public ProductBusinessRules(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task CheckIfProductEmpty(int id)
        {
            Product? result = await _productRepository.GetAsync(p => p.Id == id);
            if (result == null)  throw new BusinessException("Böyle bir ürün yok");
        }
    }
}
