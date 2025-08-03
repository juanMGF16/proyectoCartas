using AutoMapper;
using Business.Implements.Bases;
using Business.Interfaces.Querys;
using Data.Interfaces.Group.Querys;
using Entity.Dtos.Card;
using Entity.Model.Card;
using Microsoft.Extensions.Logging;
using Utilities.Helpers.Validations;

namespace Business.Implements.CQRS.Card
{
    public class MoveBusiness : BaseQueryBusiness<Move, MoveDtoQuery>, IQueryMovesServices
    {
        protected readonly IQueryAllMove _data;
        public MoveBusiness(
            IQueryAllMove data,
            IMapper mapper,
            ILogger<MoveBusiness> _logger,
            IGenericHerlpers helpers) : base(data, mapper, _logger, helpers)
        {
           _data = data;
        }


        /// <summary>
        /// Valida un DTO utilizando las reglas de validación de FluentValidation.
        /// </summary>
        /// <param name="dto">El objeto DTO a validar</param>
        /// <returns>Una tarea que representa la operación de validación asíncrona</returns>
        /// <remarks>
        /// Este método utiliza el servicio _helpers para realizar la validación.
        /// Si la validación falla, se agrupan todos los errores en una sola excepción.
        /// </remarks>
        protected async Task EnsureValid(MoveDtoQuery dto)
        {
            var validationResult = await _helpers.Validate(dto);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(", ", validationResult.Errors);
                throw new ArgumentException($"Validación fallida: {errors}");
            }
        }


        public async Task<IEnumerable<MoveDtoQuery>> GetByAllMovesService(int id)
        {
            try
            {
                var entities = await _data.QueryGenerate(id);
                _logger.LogInformation($"Obteniendo {typeof(Move).Name} con ID: {id}");
                return _mapper.Map<IEnumerable<MoveDtoQuery>>(entities);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener {typeof(Move).Name} con ID {id}: {ex.Message}");
                throw;
            }
        }





    }
}
