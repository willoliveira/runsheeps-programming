using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CountingSheeps.RunSheepsRun
{
    public enum CollectableType
    {
        Coin,
        Medic,
        Boost,
        Collectible
    }
    
    public class Collectable : ElementGame
    {
        public CollectableType CollectableType;
    }
}