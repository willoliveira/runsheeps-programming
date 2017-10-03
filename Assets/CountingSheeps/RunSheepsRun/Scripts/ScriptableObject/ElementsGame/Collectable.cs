using System;
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

	[CreateAssetMenu(fileName = "Obstacle", menuName = "RunSheepsRun/ElementGame/Collectable", order = 1)]
	[Serializable]
	public class Collectable : ElementGame
    {
        public CollectableType CollectableType;

		public Collectable()
		{
			this.ElementType = ElementTypeEnum.Collectable;
			this.CollectableType = CollectableType.Coin;
		}
    }
}