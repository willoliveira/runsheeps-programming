using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CountingSheeps.RunSheepsRun
{
    public enum ElementType
    {
        Collectable,
        Obstacle
    }

    public enum ScenaryList
    {
        Common,
        Farm
    }

    [Serializable]
    public class ElementGame : MonoBehaviour
    {
        public ElementType ElementType;

        public GameObject Prefab;

        public ScenaryList ScenaryItem = ScenaryList.Common;
    }
}