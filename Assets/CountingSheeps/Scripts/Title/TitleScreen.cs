using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour {

	public GameObject mCamera;  

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

	public void OnInitGame() {
		mCamera.GetComponent<Animator>().SetTrigger("StartGame");
	}
}
