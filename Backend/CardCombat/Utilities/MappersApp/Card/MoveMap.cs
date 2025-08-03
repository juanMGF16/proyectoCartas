using AutoMapper;
using Entity.Dtos.Card;
using Entity.Model.Card;

namespace Utilities.MappersApp.Card
{
    public class MoveMap : Profile
    {
        public MoveMap()
        {
            CreateMap<Move, MoveDto>().ReverseMap();

            CreateMap<Move, MoveDtoQuery>()
                .ForMember(dest => dest.PlayerName, opt => opt.MapFrom(src => src.Player.Name))
                .ForMember(dest => dest.CardName, opt => opt.MapFrom(src => src.Card.Name));
        }
    }
}