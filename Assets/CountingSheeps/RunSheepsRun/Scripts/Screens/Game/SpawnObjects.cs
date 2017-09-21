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
            randomObj = new Random();
            ActualDistance = Time.time;

            /**
             * TODO: Calcular tamanho da camera e colocar os obstaculos o suficiente para preencher a vista da camera na primeira vez;
             */
            CameraHorizontalSize = Camera.main.orthographicSize * Screen.width / Screen.height;

            GameObject instanceFloor = Instantiate<GameObject>(ListFloors[0], FloorContainer.transform, true);
            BoxCollider2D instanceFloorBox2D = instanceFloor.GetComponent<BoxCollider2D>();
            
            instanceFloor.transform.position = new Vector2(
                -CameraHorizontalSize,
                PointReferenceFloor.transform.position.y - ((instanceFloorBox2D.size.y / 2) * instanceFloor.transform.localScale.y)
            );
            

            GameObject instanceFloor2 = Instantiate<GameObject>(ListFloors[0], FloorContainer.transform, true);
            
            instanceFloor2.transform.position = new Vector2(
                (instanceFloor.transform.position.x + (instanceFloorBox2D.size.x * instanceFloor.transform.localScale.x)),
                PointReferenceFloor.transform.position.y - ((instanceFloorBox2D.size.y / 2) * instanceFloor.transform.localScale.y)
            );


            previousFloor = Instantiate<GameObject>(ListFloors[0], FloorContainer.transform, true);

            previousFloor.transform.position = new Vector2(
                (instanceFloor2.transform.position.x + (instanceFloorBox2D.size.x * instanceFloor2.transform.localScale.x)),
                PointReferenceFloor.transform.position.y - ((instanceFloorBox2D.size.y / 2) * instanceFloor.transform.localScale.y)
            );
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

                //Debug.Log(previousFloor.transform.position.x + " <  " + CameraHorizontalSize);
                //Debug.Log(previousFloor.transform.position.x + " <  " + (CameraHorizontalSize + player.transform.position.x));

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
