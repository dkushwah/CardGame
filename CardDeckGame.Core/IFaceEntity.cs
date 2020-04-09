using System;
using System.Collections.Generic;
using System.Text;

namespace CardDeckGame.Core
{
    public interface IFaceEntity<T>
    {
        T Face { set; get; }
    }
}
