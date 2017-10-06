using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CountingSheeps.RunSheepsRun {

    public class SpawnObjects : MonoBehaviour {

        [Header("Obstaculos que serão randomizados")]
        public List<ElementGame> ListElements;

        [Header("Prefabs")]
		public GameObject ElementContainer;
        public GameObject PointReferenceFloor;

        [Header("Minimo e maximo de disntancia para spawn os obstáculos")]
        public float SeveralMinToSpawn = 8f;
        public float DistanceToSpawnMin = 12f;
        public float DistanceToSpawnMax = 20f;

        [Header("Player Reference")]
        public Player PlayerRef;

        [Header("Score")]
        public Text score;
		
		[HideInInspector] protected float ActualDistance = 0f; //fix: no começo precisa ser maior
		[HideInInspector] protected float TimeGame = 0f;
		[HideInInspector] protected float DistanceGame = 0f;
		[HideInInspector] protected float CameraHorizontalSize;

		private void Start()
		{
			
		}

		public virtual void Init()
		{
            ActualDistance = Time.time;
			CameraHorizontalSize = Camera.main.orthographicSize * Screen.width / Screen.height;
		}
		
        protected virtual void Update()
        {
            if (!GameManager.Pause)
            {
                TimeGame += Time.deltaTime;
                //distancia em metros
                DistanceGame = (TimeGame * PlayerRef.MaxSpeed);
            }
        }

    }
}
