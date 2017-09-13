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

        private Random randomObj;

        private float ActualDistance = 0f;
        private float NextDistance;

        private float TimeGame = 0f;
        private float DistanceGame;

        private void Awake()
        {
            randomObj = new Random();
            ActualDistance = Time.time;
        }

        private void FixedUpdate()
        {   
            if (!GameManager.Pause)
            {
                World.GetComponent<Rigidbody2D>().velocity = new Vector2(-worldSpeed, 0f);
                //World.GetComponent<Rigidbody2D>().velocity = new Vector2(- worldSpeed, 0f);
                //World.transform.position = new Vector2(World.transform.position.x - worldSpeed, World.transform.position.y);                
            }
            else
            {
                World.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            }
        }

        private void Update()
        {
            if (!GameManager.Pause)
            {
                TimeGame += Time.deltaTime;
                DistanceGame = (TimeGame * worldSpeed);

                if (DistanceGame > ActualDistance)
                {
                    float RandomDistance = Random.Range(SeveralMinToSpawn, DistanceToSpawnMax);
                    ActualDistance = DistanceGame + RandomDistance;

                    //Debug.Log("RandomDistance" + RandomDistance);

                    GameObject instance = Instantiate<GameObject>(ListObstacles[Random.Range(1, 2)].Prefab, ObstaclesContainer.transform, true);
                    instance.transform.position = SpawnPosition.transform.position;


                    GameObject instanceFloor = Instantiate<GameObject>(ListFloors[0], FloorContainer.transform, true);
                    Debug.Log(instanceFloor.GetComponent<BoxCollider2D>().size.y);
                    instanceFloor.transform.position = SpawnPosition.transform.position;
                    //instanceFloor.transform.position = new Vector2(SpawnPosition.transform.position.x, SpawnPosition.transform.position.y - instanceFloor.transform.localScale.y);

                }
            }
        }
    }

}
