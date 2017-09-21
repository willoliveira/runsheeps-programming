using UnityEngine;
using System.Collections;

namespace CountingSheeps.RunSheepsRun
{
    public class CameraFolow : MonoBehaviour
    {
        public float xMarginLeft = 6f;
        public float xSmooth = 3f;
        public Transform target;

        float CameraHorizontalSize;

        private void Awake()
        {
            CameraHorizontalSize = Camera.main.orthographicSize* Screen.width / Screen.height;
            Debug.Log(CameraHorizontalSize);
            Debug.Log(PositionX());
        }

        float PositionX()
        {
            return target.position.x + CameraHorizontalSize - xMarginLeft; 
        }

        void FixedUpdate()
        {
            float targetX = Mathf.Lerp(transform.position.x, PositionX(), xSmooth * Time.deltaTime);
            float targetY = transform.position.y;

            transform.position = new Vector3(targetX, targetY, transform.position.z);
        }
    }
}