using System;
using System.Collections.Generic;

namespace CardGameApi.Controllers
{
    public class CardManager : ICardManager
    {
        private readonly Dictionary<string, int> suitesInOrder = new Dictionary<string, int>
        {
            { "T", 1 }, { "D", 2 },{ "S", 3 },{ "C", 4 },{ "H", 5 },
        };

        private readonly Dictionary<string, int> facesInOrder = new Dictionary<string, int>
        {
            {"2", 1 },{"3", 2 },{"4", 3 },{"5", 4 },{"6", 5 },{"7", 6 },{"8", 7 },{"9", 8 },{"10",9 },{"J", 10 },{"Q", 11 },{"K", 12 },{"A", 13 }
        };


        private readonly Dictionary<string, int> spacialInOrder = new Dictionary<string, int>
        {
            {"4", 1 },{"2", 2 },{"S", 3 },{"P", 4 },{"R", 5 }
        };

        private readonly List<Card> deck = new List<Card>();

        public void CreateDeck(List<string> cards)
        {
            foreach (var card in cards)
            {
                string suite = card[1].ToString().ToUpper();
                string face = card[0].ToString().ToUpper();

                if (card.Length == 3 && card.Substring(0, 2).Equals("10"))
                {
                    face = "10";
                    suite = card[2].ToString().ToUpper();
                }

                deck.Add(new Card(suite, face, this.suitesInOrder, this.facesInOrder, this.spacialInOrder));
            }
        }

        public List<string> SordCards()
        {
            deck.Sort((x, y) => x.SortCards(y));

            var result = GetResult(deck);

            return result;
        }

        private List<string> GetResult(List<Card> deck)
        {
            var strings = new List<string>();
            foreach (var card in deck)
            {
                strings.Add(card.Face + card.Suite);
            }
            return strings;
        }

        private class Card
        {
            private readonly Dictionary<string, int> suitesInOrder;
            private readonly Dictionary<string, int> facesInOrder;
            private readonly Dictionary<string, int> spacialInOrder;

            public string Suite { get; set; }
            public string Face { get; set; }

            public Card(string suite, string face, Dictionary<string, int> suitesInOrder, Dictionary<string, int> facesInOrder, Dictionary<string, int> spacialInOrder)
            {
                Suite = suite;
                Face = face;
                this.suitesInOrder = suitesInOrder;
                this.facesInOrder = facesInOrder;
                this.spacialInOrder = spacialInOrder;
            }


            public int SortCards(Card otherCard)
            {
                int s1 = this.suitesInOrder[this.Suite];
                int s2 = this.suitesInOrder[otherCard.Suite];

                if (s1 > s2)
                    return 1;
                else if (s1 < s2)
                    return -1;
                else
                {
                    if (this.Suite.Equals("T"))
                    {
                        return CompareResult(this.spacialInOrder[this.Face], this.spacialInOrder[otherCard.Face]);
                    }
                    else
                    {
                        return CompareResult(this.facesInOrder[this.Face], this.facesInOrder[otherCard.Face]);
                    }
                }
            }

            private int CompareResult(int v1, int v2)
            {
                if (v1 > v2)
                    return 1;
                else if (v1 < v2)
                    return -1;
                else
                    return 0;
            }
        }
    }
}