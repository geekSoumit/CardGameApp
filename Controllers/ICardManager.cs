using System.Collections.Generic;

namespace CardGameApi.Controllers
{
    public interface ICardManager
    {
        void CreateDeck(List<string> cards);
        List<string> SordCards();
    }
}