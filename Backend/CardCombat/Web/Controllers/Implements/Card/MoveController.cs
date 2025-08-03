using Business.Implements.CQRS.Card;
using Business.Interfaces.Commands;
using Business.Interfaces.Querys;
using Entity.Dtos.Card;
using Entity.Model.Card;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Implements.Abstract;

namespace Web.Controllers.Implements.Card
{
    public class MoveController
       : GenericController<
       Move,
       MoveDtoQuery,
       MoveDto>
    {

        //public readonly MoveBusiness _querySvc;


        public MoveController(
            //MoveBusiness q,
            IQueryServices<Move, MoveDtoQuery> q, 
            ICommandService<Move, MoveDto> c)
          : base(q, c) 
        { 
            //_querySvc = q;
        }



        [HttpGet("/cartasJugador/{id}")]
        public async Task<IActionResult> GetAllMovesId(int id) 
        {
            var dataMove = await _querySvc.GetByAllMovesService(id);
            return Ok(await _querySvc.GetByIdServices(id));
        }

    }

}
