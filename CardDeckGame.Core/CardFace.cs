using System;
using System.Collections.Generic;
using System.Text;

namespace CardDeckGame.Core
{
    public class CardFace<T> : IFaceEntity<T>
    {
        public T Face { get; set; }
    }
}
