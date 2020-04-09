using System;

namespace CardDeckGame.Core
{
    public class LsCard : Card<Suits, Face>
    {
        public LsCard(ISuitEntity<Suits> suitEntity, IFaceEntity<Face> faceEntity) : base(suitEntity, faceEntity)
        {

        }

        public override int GetFaceValue()
        {
            return (int)Face.Face;
        }

        public override void PrintCard()
        {
            Console.WriteLine($"Suit: {Suit.Suit} Face: {Face.Face}");
        }
        public override string ToString()
        {
            return $"Suit: {Suit.Suit} Face: {Face.Face} Face Value: {(int)Face.Face}";
        }
    }
}
