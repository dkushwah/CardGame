using CardDeckGame.Contract;
using CardDeckGame.Core;
using System;
using System.Collections.Generic;

namespace CardDeckGame.Impl
{
    /// <summary>
    ///  Enum based Deck implementation for IDeck
    /// </summary>
    public class CardRepository : ICardRepository<Suits,Face>
    {
        private readonly ISuitsStore<Suits> _suitsStore;
        private readonly IFaceStore<Face> _faceStore;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="suitsStore"></param>
        /// <param name="faceStore"></param>
        public CardRepository(ISuitsStore<Suits> suitsStore,IFaceStore<Face> faceStore)
        {
            this._suitsStore = suitsStore;
            this._faceStore = faceStore;
        }

        /// <summary>
        /// GenerateCards generate number of cards based on the available faces and suits on stores
        /// </summary>
        /// <returns></returns>
       public IEnumerable<Card<Suits, Face>> GetCards()
        {
            foreach (var suit in _suitsStore.GetAllSuits())
            {
                foreach (var face in _faceStore.GetAllCardFaces())
                {
                    yield return new LsCard(suit, face);
                }
            }
        }
    }
}
