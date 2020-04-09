using System;
using System.Collections.Generic;
using System.Text;

namespace CardDeckGame.Core
{
    public class CardSuit<T> : ISuitEntity<T>
    {
        public T Suit { get; set; }
    }
}
