using System;
using System.Collections.Generic;
using System.Text;

namespace CardDeckGame.Core
{
    public interface ISuitEntity<T>
    {
        T Suit { get; set; }
    }
}
