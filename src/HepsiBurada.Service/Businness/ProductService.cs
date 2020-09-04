using System.Threading;
using System.Threading.Tasks;
using HepsiBurada.Core.Businness;
using HepsiBurada.Core.Model;
using HepsiBurada.Core.Persistence;

namespace HepsiBurada.Service.Businness
{
    public class ProductService : IProductService, IService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> CreateProduct(Product product, CancellationToken cancellationToken)
        {
            //todo is it necessary to control. Code is ID actually
            if(await _productRepository.Get(product.Code, cancellationToken) != null)
            {
                throw new System.Exception($"product {product.Code} has already been defined");
            }
            product.Code = await _productRepository.Save(product, cancellationToken);
            return product;
        }

        public async Task<Product> GetProduct(string code, CancellationToken cancellationToken)
        {
            return await _productRepository.Get(code, cancellationToken);
        }
    }
}
