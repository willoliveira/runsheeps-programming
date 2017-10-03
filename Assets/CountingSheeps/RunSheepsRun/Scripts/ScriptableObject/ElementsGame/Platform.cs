using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CountingSheeps.RunSheepsRun
{
    public enum PlatformType
    {
        Ground,
		Floating
    }

	[CreateAssetMenu(fileName = "Obstacle", menuName = "RunSheepsRun/ElementGame/Platform", order = 2)]
	[Serializable]
	public class Platform : ElementGame
    {
        public PlatformType PlatformType;

		public Platform()
		{
			this.ElementType = ElementTypeEnum.Platform;
			this.PlatformType = PlatformType.Ground;
		}
	}
}