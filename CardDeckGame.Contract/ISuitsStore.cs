using CardDeckGame.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardDeckGame.Contract
{
    public interface ISuitsStore<T>
    {
        IEnumerable<ISuitEntity<T>> GetAllSuits();
    }
}
