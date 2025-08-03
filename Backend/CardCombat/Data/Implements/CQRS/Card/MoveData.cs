using Data.Implements.Querys;
using Data.Interfaces.Group.Querys;
using Entity.Context.Main;
using Entity.Model.Card;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.Implements.CQRS.Card
{
    public class MoveData : BaseGenericQuerysData<Move>, IQueryAllMove
    {
        protected readonly ILogger<MoveData> _logger;
        protected readonly AplicationDbContext _dbContext;

        public MoveData(ILogger<MoveData> logger, AplicationDbContext dbContext) : base(dbContext, logger)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public override async Task<IEnumerable<Move>> QueryAllAsyn()
        {
            try
            {
                var model = await _dbContext.Move
                    .Include(ur => ur.Player)
                    .Include(ur => ur.Card)
                    .ToListAsync();

                _logger.LogInformation("Consulta de la enidad {Entity} se realizo exitosamente", typeof(Move).Name);
                return model;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "Error en la consulta la entidad {Entity}", typeof(Move).Name);
                throw;
            }
        }

        public async Task<IEnumerable<Move>> QueryGenerate(int id)
        {
            try
            {
                var model = await _dbContext.Move
                    .Include(ur => ur.Player)
                    .Include(ur => ur.Card)
                    .Where(ur => ur.PlayerId == id)
                    //.Select(ur => ur.Card)
                    .ToListAsync();

                _logger.LogInformation("Consulta de la enidad {Entity} se realizo exitosamente", typeof(Move).Name);
                return model;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "Error en la consulta la entidad {Entity}", typeof(Move).Name);
                throw;
            }
        }

    }
}
