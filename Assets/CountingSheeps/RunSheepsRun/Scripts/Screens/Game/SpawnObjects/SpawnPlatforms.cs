using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CountingSheeps.RunSheepsRun {

    public class SpawnPlatforms : SpawnObjects {

        private GameObject previousFloor;
		private float RandomDistance = 0f;

		private void Start()
		{
			this.Init();
		}

		public override void Init()
		{
			base.Init();

			InitialPlatformObjects();

			EventManager.StartListening("GAME_EXIT", DestroyPlatforms);
		}

	    /**
        * TODO: Refatorar o lance da camera, ter mais controle sobre ela
        */
		public void InitialPlatformObjects() { 

			Platform platform = (Platform) ListElements[0];
			
			BoxCollider2D cacheBoxCollider2D = platform.Prefab.GetComponent<BoxCollider2D>();
			Transform cacheTransform = platform.Prefab.transform;

			int NumPlatforms = Mathf.CeilToInt((CameraHorizontalSize * 4) / (cacheBoxCollider2D.size.x * cacheTransform.localScale.x));
			float pointPositionY = PointReferenceFloor.transform.position.y - ((cacheBoxCollider2D.size.y / 2) * cacheTransform.localScale.y);

			//TODO: Instancio o primeiro aqui, se pa mudar isso
			GameObject previousInstanceFloor = null;
			GameObject instanceFloor = Instantiate<GameObject>(
				platform.Prefab, 
				new Vector3(-CameraHorizontalSize + Camera.main.transform.position.x, pointPositionY), 
				Quaternion.identity, 
				ElementContainer.transform
			);

			for (int cont = 0, len = NumPlatforms; cont < len; cont++)
			{
				if (previousInstanceFloor)
				{
					instanceFloor = Instantiate<GameObject>(
						platform.Prefab, 
						new Vector3((previousInstanceFloor.transform.position.x + (cacheBoxCollider2D.size.x * previousInstanceFloor.transform.localScale.x)), pointPositionY), 
						Quaternion.identity,
						ElementContainer.transform
					);
				}
				previousInstanceFloor = instanceFloor;
			}

			previousFloor = previousInstanceFloor;
        }

        protected override void Update()
        {
			base.Update();

			Platform platform = (Platform)ListElements[0];
			//da spawn nas plataformas
			if (DistanceGame > ActualDistance &&
				(
					previousFloor && 
					previousFloor.transform.position.x < (CameraHorizontalSize + Camera.main.transform.position.x)
				)
			)
			{
				if (!GameManager.Pause && GameManager.CurrentScreen == Screens.Game)
				{
					RandomDistance = Mathf.Floor(Random.Range(DistanceToSpawnMin, DistanceToSpawnMax));
					ActualDistance = DistanceGame + RandomDistance;
				}

				// todo: mudar a instanciação
				GameObject instanceFloor = Instantiate<GameObject>(platform.Prefab, ElementContainer.transform, true);
				BoxCollider2D instanceFloorBox2D = instanceFloor.GetComponent<BoxCollider2D>();

				float FloorPosY = PointReferenceFloor.transform.position.y - ((instanceFloorBox2D.size.y / 2) * instanceFloor.transform.localScale.y);
				float FloorPosX = RandomDistance + previousFloor.transform.position.x + (instanceFloorBox2D.size.x * instanceFloor.transform.localScale.x);
				instanceFloor.transform.position = new Vector2(FloorPosX, FloorPosY);

				previousFloor = instanceFloor;
			}
        }

		private void Clear()
		{
			RandomDistance = 0f;
		}

		private void DestroyPlatforms()
		{
			this.Clear();

			foreach (Transform platformChild in ElementContainer.transform)
			{
				Destroy(platformChild.gameObject);
			}

			this.InitialPlatformObjects();

		}
    }
}
