using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CountingSheeps.RunSheepsRun {

    public class SpawnObstacles : SpawnObjects {

        private Random random;

		public override void Init()
		{
			base.Init();
			
			EventManager.StartListening("GAME_EXIT", DestroyObstacles);
		}

		public void Destroy()
		{
			EventManager.StopListening("GAME_EXIT", DestroyObstacles);
		}

		protected override void Update()
        {
			base.Update();

			if (!GameManager.Pause && GameManager.Status == StatusGame.InGame)
            {
                //da spawn dos obstaculos
                if (DistanceGame > ActualDistance)
                {
					Obstacle obstacle = (Obstacle) ListElements[Random.Range(0, 2)];
					float RandomDistance = Random.Range(DistanceToSpawnMin, DistanceToSpawnMax);

                    ActualDistance = DistanceGame + RandomDistance;

                    GameObject instanceObstacle = Instantiate<GameObject>(obstacle.Prefab, ElementContainer.transform, true);
                    BoxCollider2D instancObstacleBox2D = instanceObstacle.GetComponent<BoxCollider2D>();

                    float ObstacleY = PointReferenceFloor.transform.position.y;
                    float ObstacleX = Camera.main.transform.position.x + (CameraHorizontalSize * 1.5f);
                    instanceObstacle.transform.position =  new Vector2(ObstacleX, ObstacleY);
                }
            }
        }

		private void DestroyObstacles()
		{
			foreach (Transform platformChild in ElementContainer.transform)
			{
				Destroy(platformChild.gameObject);
			}
		}


	}
}
