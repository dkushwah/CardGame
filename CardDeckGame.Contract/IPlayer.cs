using CardDeckGame.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardDeckGame.Contract
{
    public interface IPlayer
    {
        IDeck<Suits, Face> Deck { get; set; }

        string Name { get; set; }
    }
}
