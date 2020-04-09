using CardDeckGame.Contract;
using CardDeckGame.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardDeckGame.Impl
{
    public class FaceStore : IFaceStore<Face>
    {
        public IEnumerable<IFaceEntity<Face>> GetAllCardFaces()
        {
            foreach (var item in (Face[])Enum.GetValues(typeof(Face)))
            {
                yield return new FaceEntity { Face = item };
            }
        }
    }
}
