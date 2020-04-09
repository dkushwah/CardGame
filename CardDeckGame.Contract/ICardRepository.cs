using CardDeckGame.Core;
using System.Collections.Generic;
using System.Text;

namespace CardDeckGame.Contract
{
    public interface ICardRepository<TSuits,TFace>
    {
        IEnumerable<Card<TSuits,TFace>> GetCards();
    }
}
