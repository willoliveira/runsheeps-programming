using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CountingSheeps.RunSheepsRun
{
    public enum TypesObstacles
    {
        Low,
        Middle,
        High
    }

    [Serializable]
    public class Obstacle : ElementGame
    {
        public TypesObstacles TypesObstacle;

        public int HitPoint = 1;
    }
}