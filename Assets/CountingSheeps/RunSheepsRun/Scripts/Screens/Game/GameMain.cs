using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace CountingSheeps.RunSheepsRun
{

    // TODO: FAZER UM METODO GENERICO PARA POP UP
    public class GameMain : MonoBehaviour
    {

        #region PUBLIC VARS
        public Player player;
        #endregion

        #region PRIVATE VARS
        private GameScreen gameReference;
        private SpawnObjects spawnObjects;

        //flag de inicio de jogo
        private bool flagInitGame = false;
        #endregion

        private void Awake()
        {
            spawnObjects = GetComponent<SpawnObjects>();
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
        public void InitGame()
        {
            //seta o inicio do jogo
            flagInitGame = true;

            spawnObjects.gameObject.SetActive(true);
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