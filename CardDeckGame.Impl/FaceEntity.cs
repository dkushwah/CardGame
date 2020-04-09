using CardDeckGame.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardDeckGame.Impl
{
    public class FaceEntity : IFaceEntity<Face>
    {
        public Face Face { get; set; }
    }
}
