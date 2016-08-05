using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ScreenOpen()
	{
		//seta e tela atual
		GameManager.CurrentScreen = Screens.Title;
	}

	public void ScreenExit()
	{
		gameObject.SetActive(false);
		//Abre a proxima tela
	}
}
