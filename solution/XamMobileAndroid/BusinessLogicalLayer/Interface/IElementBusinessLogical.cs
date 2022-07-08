using EntityFrameworkLayer.Entities;
using EntityFrameworkLayer.ExecuteDto;
using EntityFrameworkLayer.RequestDto;

namespace BusinessLogicalLayer.Interface
{
    /// <summary>
    /// Interface permettant la recherche et le traitement de l’entité <see cref="Element"/>.
    /// </summary>
    public interface IElementBusinessLogical : IBaseBusinessLogical<Element, ElementRequestDto, ElementExecuteDto, ElementCheckDto>
    {
    }
}