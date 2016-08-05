using UnityEngine;
using System.Collections;

public enum Screens
{
	Title,
	Game,
	Store,
	DailyChallenge
}

public class GameManager : MonoBehaviour {

	#region PUBLIC VARS
	public static GameManager Instance
	{
		get
		{
			if (!gameManager)
			{
				gameManager = FindObjectOfType(typeof(GameManager)) as GameManager;

				if (!gameManager)
				{
					Debug.LogError("There needs to be one active GameManger script on a GameObject in your scene.");
				}
			}
			return gameManager;
		}
	}

	public static bool Pause
	{
		get { return pauseGame; }
		set { pauseGame = value; }
	}

	public static Screens CurrentScreen
	{
		get { return currentScreen; }
		set { currentScreen = value; }
	}
	#endregion

	#region PRIVATE VARS
	private static bool pauseGame;
	private static GameManager gameManager;
	private static Screens currentScreen;
	#endregion



}
