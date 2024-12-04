using System;
using System.Collections.Generic;

namespace GAME
{
    [Serializable]
    public class GemSystemData
    {
        public bool IsBuzyGems;         // Камни находятся в процессе перемещения
        public List<GemObject> Gems;
    }
}
