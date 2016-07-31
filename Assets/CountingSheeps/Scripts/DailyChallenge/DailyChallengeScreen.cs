using UnityEngine;
using System.Collections;

public class DailyChallengeScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ScreenExit()
	{
		Debug.Log("ScreenExit");
		gameObject.SetActive(false);
		//Abre a proxima tela
	}
}
