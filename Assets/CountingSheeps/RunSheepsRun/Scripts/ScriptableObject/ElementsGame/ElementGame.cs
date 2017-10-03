using MoreMountains.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CountingSheeps.RunSheepsRun
{
    public enum ElementTypeEnum
    {
        Collectable,
        Obstacle,
		Platform
    }

    public enum ScenaryEnum
    {
        Common,
        Farm
    }

    [Serializable]
    public class ElementGame : ScriptableObject
    {
        [Header("Propriedades")]
        public string ElementID;

        public ElementTypeEnum ElementType;

        public GameObject Prefab;

        public ScenaryEnum ScenaryItem = ScenaryEnum.Common;
    }
}