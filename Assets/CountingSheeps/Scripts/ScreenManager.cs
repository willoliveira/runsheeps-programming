using UnityEngine;
using System.Collections;

public class ScreenManager : MonoBehaviour
{

	public GameObject TitleScreen;
	public GameObject GameScreen;
	public GameObject StoreScreen;
	public GameObject DailyChallenge;



	public GameObject previousScreen;
	public GameObject currentScreen;


	private static ScreenManager screenManager;

	public static ScreenManager instance
	{
		get
		{
			if (!screenManager)
			{
				screenManager = FindObjectOfType(typeof(ScreenManager)) as ScreenManager;

				if (!screenManager)
				{
					Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
				}
				else
				{
					screenManager.Init();
				}
			}
			return screenManager;
		}
	}

	void Init()
	{

	}

	public void OpenScreen(GameObject OpenScreen, GameObject CloseScreen)
	{
		//
		CloseScreen.GetComponent<Animator>().SetTrigger("Close");
		//
		OpenScreen.GetComponent<Animator>().SetTrigger("Open");
	}

	public void OpenGame()
	{
		GameScreen.SetActive(true);
		GameScreen.GetComponent<Animator>().SetTrigger("Open");
	}
}
