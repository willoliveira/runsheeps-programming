using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CountingSheeps.RunSheepsRun {

    public class SpawnObjects : MonoBehaviour {

        public List<Obstacle> ListObstacles;
        public GameObject ObstaclesContainer;
        public GameObject SpawnPosition;
        public float IntervalToSpawnElements;
        public GameObject World;
        public float worldSpeed = 0.1f;
        public Text score;

        private float ActualTime = 0f;
        private float NextTime;

        private void Awake()
        {
            ActualTime = Time.time;
        }

        private void FixedUpdate()
        {   
            if (!GameManager.Pause)
            {
                World.transform.position = new Vector2(World.transform.position.x - worldSpeed, World.transform.position.y);
            }
        }

        private void Update()
        {
            //Debug.Log("Time.time: " + ActualTime + " | NextTime: " + NextTime);
            if (!GameManager.Pause)
            {
                if (ActualTime > NextTime)
                {
                    NextTime = Time.time + IntervalToSpawnElements;

                    GameObject instance = Instantiate<GameObject>(ListObstacles[2].Prefab, ObstaclesContainer.transform, true);
                    instance.transform.position = SpawnPosition.transform.position;
                }
                ActualTime = Time.time;
            }
            else if (Time.time > ActualTime)
            {
                NextTime = (NextTime - Time.time + IntervalToSpawnElements);
            }
        }
    }

}
