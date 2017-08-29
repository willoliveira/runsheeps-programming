using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CountingSheeps.RunSheepsRun
{
        
    public enum CoinType
    {
        Low,
        Middle,
        High
    }

    public class CollectableCoins : MonoBehaviour
    {

        public CoinType Coins = CoinType.Low;
   
    }
}