using MoreMountains.Tools;
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

    [CreateAssetMenu(fileName = "Obstacle", menuName = "RunSheepsRun/ElementGame/Obstacle", order = 0)]
    [Serializable]
    public class Obstacle : ElementGame
    {
		public Obstacle()
        {
            this.ElementType = ElementTypeEnum.Obstacle;
            this.TypesObstacle = TypesObstacles.Low;
        }

        [Header("Obstacle")]
        [Information("Propriedades referente ao obstáculo", InformationAttribute.InformationType.Info, false)]
        public TypesObstacles TypesObstacle;

        [Information("Força do hit que o personagem irá tomar", InformationAttribute.InformationType.Info, false)]
        public int HitPoint = 1;
        
        public bool OneHitDie = true;
    }
}