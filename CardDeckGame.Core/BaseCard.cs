using System;

namespace CardDeckGame.Core
{
    public abstract class Card<TSuit, TFace>
    {
        public ISuitEntity<TSuit> Suit { get; }
        public IFaceEntity<TFace> Face { get; }

        public Card(ISuitEntity<TSuit> suitEntity, IFaceEntity<TFace> faceEntity)
        {
            Suit = suitEntity;
            Face = faceEntity;
        }
        public abstract void PrintCard();
        public abstract int GetFaceValue();
    }
}
