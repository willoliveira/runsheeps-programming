using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CountingSheeps.RunSheepsRun {

    public class SpawnObjects : MonoBehaviour {

        [Header("Obstaculos que serão randomizados")]
        public List<Obstacle> ListObstacles;
        public List<GameObject> ListFloors;

        [Header("Prefabs")]
        public GameObject FloorContainer;
        public GameObject ObstaclesContainer;
        public GameObject PointReferenceFloor;
        public GameObject SpawnPosition;
        public GameObject World;

        [Header("Minimo e maximo de disntancia para spawn os obstáculos")]
        public float SeveralMinToSpawn = 8f;
        public float DistanceToSpawnMin = 12f;
        public float DistanceToSpawnMax = 20f;

        [Header("World Speed")]
        public float worldSpeed = 0.1f;

        [Header("Score")]
        public Text score;

        public GameObject player;

        private Random randomObj;

        private float ActualDistance = 0f;
        private float NextDistance;

        private float TimeGame = 0f;
        private float DistanceGame;

        private GameObject previousFloor;

        private float CameraHorizontalSize;

		private void Awake()
		{
			InitialSpawnObjects();
		}

		public void InitialSpawnObjects() { 
            randomObj = new Random();
            ActualDistance = Time.time;

            /**
             * TODO: Refatorar o lance da camera, ter mais controle sobre ela
             */
            CameraHorizontalSize = Camera.main.orthographicSize * Screen.width / Screen.height;
			

			BoxCollider2D cacheBoxCollider2D = ListFloors[0].GetComponent<BoxCollider2D>();
			Transform cacheTransform = ListFloors[0].transform;

			int NumPlatforms = Mathf.CeilToInt((CameraHorizontalSize * 4) / (cacheBoxCollider2D.size.x * cacheTransform.localScale.x));
			float pointPositionY = PointReferenceFloor.transform.position.y - ((cacheBoxCollider2D.size.y / 2) * cacheTransform.localScale.y);

			GameObject previousInstanceFloor = null;
			GameObject instanceFloor = Instantiate<GameObject>(ListFloors[0], new Vector3(-CameraHorizontalSize, pointPositionY), Quaternion.identity, FloorContainer.transform);
			for (int cont = 0, len = NumPlatforms; cont < len; cont++)
			{
				if (previousInstanceFloor)
				{
					instanceFloor = Instantiate<GameObject>(ListFloors[0], new Vector3((previousInstanceFloor.transform.position.x + (cacheBoxCollider2D.size.x * previousInstanceFloor.transform.localScale.x)), pointPositionY), Quaternion.identity, FloorContainer.transform);
				}
				previousInstanceFloor = instanceFloor;
			}

			previousFloor = previousInstanceFloor;
        }

        private void FixedUpdate()
        {
            //if (!GameManager.Pause)
            //{
            //    World.GetComponent<Rigidbody2D>().velocity = new Vector2(-worldSpeed, 0f);
            //    //World.GetComponent<Rigidbody2D>().velocity = new Vector2(- worldSpeed, 0f);
            //    //World.transform.position = new Vector2(World.transform.position.x - worldSpeed, World.transform.position.y);
            //}
            //else
            //{
            //    World.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            //}
        }

        private void Update()
        {
            if (!GameManager.Pause)
            {
                TimeGame += Time.deltaTime;
                //distancia em metros
                DistanceGame = (TimeGame * worldSpeed);

                //da spawn dos obstaculos
                if (DistanceGame > ActualDistance)
                {
                    //Debug.Log("(DistanceGame > ActualDistance) | DistanceGame: " + DistanceGame + " ActualDistance: " + ActualDistance);
                    float RandomDistance = Random.Range(DistanceToSpawnMin, DistanceToSpawnMax);
                    ActualDistance = DistanceGame + RandomDistance;

                    GameObject instanceObstacle = Instantiate<GameObject>(ListObstacles[Random.Range(0, 2)].Prefab, ObstaclesContainer.transform, true);
                    BoxCollider2D instancObstacleBox2D = instanceObstacle.GetComponent<BoxCollider2D>();

                    float ObstacleY = PointReferenceFloor.transform.position.y;
                    float ObstacleX = Camera.main.transform.position.x + (CameraHorizontalSize * 1.5f);
                    instanceObstacle.transform.position =  new Vector2(ObstacleX, ObstacleY);
                }
				

                //da spawn dos plataformas
                if (previousFloor && previousFloor.transform.position.x < (CameraHorizontalSize + Camera.main.transform.position.x))
                {
                    GameObject instanceFloor = Instantiate<GameObject>(ListFloors[0], FloorContainer.transform, true);
                    BoxCollider2D instanceFloorBox2D = instanceFloor.GetComponent<BoxCollider2D>();

                    float FloorPosY = PointReferenceFloor.transform.position.y - ((instanceFloorBox2D.size.y / 2) * instanceFloor.transform.localScale.y);
                    float FloorPosX = previousFloor.transform.position.x + (instanceFloorBox2D.size.x * instanceFloor.transform.localScale.x);
                    instanceFloor.transform.position = new Vector2(FloorPosX, FloorPosY);

                    previousFloor = instanceFloor;
                }
            }
        }

    }
}
