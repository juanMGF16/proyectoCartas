using Entity.Dtos.Global;
using Entity.Model.Global;

namespace Entity.Dtos.Card
{
    public class MoveDtoQuery : ABaseDto
    {
        public int CardId { get; set; }
        public string CardName { get; set; }
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public int Result { get; set; }
        public int RoundId { get; set; }
    }

}

