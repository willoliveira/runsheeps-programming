using UnityEngine;
using System.Collections;

public class DailyChallengeScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ScreenOpen()
	{
		//Debug.Log("DailyChallengeScreen ScreenOpen");
	}

	public void ScreenExit()
	{
		//Debug.Log("DailyChallengeScreen ScreenExit");
		gameObject.SetActive(false);
	}
}
