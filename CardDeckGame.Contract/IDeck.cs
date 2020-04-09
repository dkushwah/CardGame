using CardDeckGame.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardDeckGame.Contract
{
    public interface IDeck<TSuit, TFace>
    {
        IList<Card<TSuit, TFace>> Cards { get; set; }
        void GenerateDeck();
        void ShuffleCard();
        bool IsDeckEmpty();
        Card<TSuit, TFace> DrawCard();
        void AddCardsInDeck(Card<TSuit, TFace>[] cards);
    }
}
