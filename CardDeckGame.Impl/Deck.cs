using CardDeckGame.Contract;
using CardDeckGame.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardDeckGame.Impl
{
    /// <summary>
    /// 
    /// </summary>
    public class Deck : IDeck<Suits, Face>
    {
        private readonly ICardRepository<Suits, Face> _cardRepository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cardRepository"></param>
        public Deck(ICardRepository<Suits, Face> cardRepository)
        {
            this._cardRepository = cardRepository;
        }
        public IList<Card<Suits, Face>> Cards { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cards"></param>
        public void AddCardsInDeck(Card<Suits, Face>[] cards)
        {
            cards?.ToList().ForEach(t =>
            {
                Cards.Add(t);
            });
            ShuffleCard();
        }

        public Card<Suits, Face> DrawCard()
        {
            var card = Cards[0];
            Cards.Remove(card);
            return card;
        }

        public void GenerateDeck()
        {
            Cards = _cardRepository.GetCards().ToList();
        }

        public bool IsDeckEmpty()
        {
            return Cards?.Count <= 0;
        }

        public void PlayCard()
        {
            var card = Cards[0];
        }

        public void ShuffleCard()
        {
            Cards = Cards.OrderBy(t => Guid.NewGuid()).ToList();
        }
    }
}
