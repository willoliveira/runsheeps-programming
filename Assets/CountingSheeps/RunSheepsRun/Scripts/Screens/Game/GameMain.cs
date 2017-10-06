using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace CountingSheeps.RunSheepsRun
{

    public class GameMain : MonoBehaviour
    {

        #region PUBLIC VARS
        public Player player;
        #endregion

        #region PRIVATE VARS
        private GameScreen gameReference;
        private SpawnObstacles spawnObstacles;

        //flag de inicio de jogo
        private bool flagInitGame = false;
        #endregion

        private void Awake()
        {
			spawnObstacles = GetComponent<SpawnObstacles>();
        }

        private void Update()
        {
            if (flagInitGame && !GameManager.Pause)
            {
                UpdateChar();
            }
        }

        private void OnDestroy()
        {
            flagInitGame = false;
        }

        #region PUBLIC_METHODS
        /// <summary>
        /// Inicializa o game
        /// </summary>
        public void Init()
        {
            //seta o inicio do jogo
            flagInitGame = true;

			spawnObstacles.Init();

			GameManager.Status = StatusGame.InGame;
        }

		public void Destroy()
		{
			spawnObstacles.Destroy();
			GameManager.Status = StatusGame.OutGame;
		}

		#endregion

		#region PRIVATE_METHODS
		private void UpdateChar()
        {
            if (Input.GetButtonDown("Jump") || Input.touchCount > 0)
            {
                player.JumpAction();
            }
        }
        #endregion

    }
}