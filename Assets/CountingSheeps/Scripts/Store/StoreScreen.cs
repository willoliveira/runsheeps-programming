using UnityEngine;
using System.Collections;

public class StoreScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void ScreenOpen()
	{
		//Debug.Log("StoreScreen ScreenOpen");
		//seta e tela atual
		GameManager.CurrentScreen = Screens.Store;
	}

	public void ScreenExit()
	{
		//Debug.Log("StoreScreen ScreenExit");
		gameObject.SetActive(false);
		//Abre a proxima tela
	}
}
