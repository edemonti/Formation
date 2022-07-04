using EntityFrameworkLayer.Entities;
using EntityFrameworkLayer.ExecuteDto;
using EntityFrameworkLayer.RequestDto;

namespace DataAccessLayer.Interface
{
    /// <summary>
    /// Interface permettant la recherche et le traitement de l’entité <see cref="Product"/>.
    /// </summary>
    public interface IProductDataAccess : IBaseDataAccess<Product, ProductRequestDto, ProductExecuteDto>
    {
    }
}