using Data.Interfaces.Basic;
using Entity.Model.Card;
using Entity.Model.Global;

namespace Data.Interfaces.Group.Querys
{

    /// <summary>
    /// Interfaz que me define los métodos de consultas comunes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IQueryAllMove : IQuerys<Move>
    {
        Task<IEnumerable<Move>> QueryGenerate(int id);
    }
}
