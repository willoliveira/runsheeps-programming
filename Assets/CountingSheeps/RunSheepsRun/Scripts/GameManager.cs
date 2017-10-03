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


namespace CountingSheeps.RunSheepsRun
{
    public class GameManager : MonoBehaviour
    {
        #region PRIVATE VARS
        private static bool pauseGame;
        private static GameManager gameManager;
        private static Screens currentScreen;
        #endregion

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

        //GameSettings
        public int coins;
        public static int Coins
        {
            get { return Instance.coins; }
            set { Instance.coins = value; }
        }

        public CharacterDefinition defaultCharacter;
        public static CharacterDefinition DefaultCharacter
        {
            get { return Instance.defaultCharacter; }
        }

        public CharacterDefinition characterSelect;
        public static CharacterDefinition CharacterSelect
        {
            get { return Instance.characterSelect; }
            set { Instance.characterSelect = value; }
        }

        public List<CharacterDefinition> listCharacters = new List<CharacterDefinition>();
        public static List<CharacterDefinition> ListCharacters
        {
            get { return Instance.listCharacters; }
        }
        //GameSettings
        #endregion


        void Awake()
        {
            Application.targetFrameRate = 30;
        }
    }
}