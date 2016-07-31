using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OnInitial()
	{
		//Fecha a minha tela
		//anim.SetTrigger("Close");
		//Abre a proxima tela
		//ScreenManager.instance.OpenScreen(gameObject);
		//ScreenManager.instance.OpenGame();
	}

	public void OnStore()
	{
		//Fecha a minha tela
		//anim.SetTrigger("Close");
		//Abre a proxima tela
	}

	public void OnDailyChallenge()
	{
		//Fecha a minha tela
		//anim.SetTrigger("Close");
		//Abre a proxima tela
	}

	public void ScreenExit()
	{
		Debug.Log("ScreenExit");
		gameObject.SetActive(false);
		//Abre a proxima tela
	}
}
