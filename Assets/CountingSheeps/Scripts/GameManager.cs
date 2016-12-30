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

	public static Config Config
	{
		get { return config; }
	}

	public static GameData GameData
	{
		get { return gameData; }
		set { gameData = value; }
	}

	public Config ConfigFile;
	#endregion

	#region PRIVATE VARS
	private static bool pauseGame;
	private static GameManager gameManager;
	private static Screens currentScreen;
	private static Config config;
	private static GameData gameData;
	#endregion

	void Awake()
	{
		Application.targetFrameRate = 30;

		config = ConfigFile;
		
		LoadData();
		//Debug.Log(data.coins);
		//Debug.Log(data.characterSelect);
		//Debug.Log(data.listCharacters.Count);
	}

	private void LoadData()
	{
		gameData = new GameData();
		GameData data = DataPersist.Load<GameData>() as GameData;
		if (data == null)
		{			
			gameData.characterSelect = Config.DefaultCharacter.name;
			gameData.coins = Config.coins;
			//gameData.listCharacters = Config.ListCharacters;

			Debug.Log(gameData.coins);
			Debug.Log(gameData.characterSelect);

			DataPersist.Save<GameData>(gameData);
		}
		else
		{
			Debug.Log(data.coins);
			Debug.Log(data.characterSelect);
			//Debug.Log(data.listCharacters.Count);

			gameData = data;
		}
	}

}
