using Entity.Dtos.Card;
using Entity.Model.Card;

namespace Business.Interfaces.Querys
{
    public interface IQueryMovesServices : IQueryServices<Move, MoveDtoQuery>
    {
        Task<IEnumerable<MoveDtoQuery>> GetByAllMovesService();
       
    }
}
