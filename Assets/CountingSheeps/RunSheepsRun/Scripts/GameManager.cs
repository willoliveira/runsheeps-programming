using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public enum Screens
{
    Title,
    Game,
    Store,
    DailyChallenge
}


public enum StatusGame
{
	InGame,
	OutGame
}

namespace CountingSheeps.RunSheepsRun
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager gameManager;

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

		public static bool Pause;

		public static Screens CurrentScreen;

		public static StatusGame Status;

		
		public int coins;
        public static int Coins
        {
            get { return Instance.coins; }
            set { Instance.coins = value; }
        }

		public static CharacterDefinition DefaultCharacter;

		public static CharacterDefinition CharacterSelect;

		public static List<CharacterDefinition> ListCharacters;
		#endregion


		void Awake()
        {
			ListCharacters = new List<CharacterDefinition>();
			Status = StatusGame.OutGame;
            Application.targetFrameRate = 30;
        }
    }
}