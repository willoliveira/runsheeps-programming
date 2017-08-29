using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CountingSheeps.RunSheepsRun {

    public enum TYPE_OBSTACLES
    {
        LOW,
        MIDDLE,
        HIGH
    }

    public class SpawnObjects : MonoBehaviour {
        
        public struct Obstacles
        {
            GameObject instance;
            TYPE_OBSTACLES type;
        }

        public Obstacles[] listObstacles;

	    // Use this for initialization  
	    void Start () {
		
	    }
	
	    // Update is called once per frame
	    void Update () {
		
	    }
    }

}
