using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using DoozyUI;

namespace CountingSheeps.RunSheepsRun
{
    // TODO: FAZER UM METODO GENERICO PARA POP UP
    public class GameScreen : MonoBehaviour
    {

        #region PUBLIC VARS
        public GameObject GameOverScreen;
        public GameObject QuitGame;
        public GameObject ReturnGame;

        public Text ScoreText;
        //quando der game over
        public bool gameOverGame;
        #endregion

        #region PRIVATE VARS
        private int Score = 0;
        //controle de pause
        private bool beforePause;
        private bool afterPause;
        //quando reseta a jogada
        private bool firstPlay = true;

        private GameMain gameMain;
        #endregion


        void Start()
        {
            //quando reseta a jogada
            firstPlay = true;

            gameMain = GetComponent<GameMain>();
        }

        void Update()
        {
            beforePause = GameManager.Pause;

            if (!firstPlay && afterPause && beforePause != afterPause)
            {
				returnGame();
				//StartCoroutine(returnGame());
			}
            else
            {
                firstPlay = false;
            }
            afterPause = GameManager.Pause;
        }

        #region PUBLIC METHODS
        /// <summary>
        /// Chamado quando a janela é aberta
        /// </summary>
        public void ScreenOpen()
        {;
            //quando reseta a jogada
            firstPlay = true;
            beforePause = false;
            afterPause = false;

            GameManager.Pause = false;

            //seta e tela atual
            GameManager.CurrentScreen = Screens.Game;
            //inicia o game
            gameMain.Init();
        }
        /// <summary>
        /// Chamado quando a janela é fechada
        /// </summary>
        public void ScreenExit()
        {
			Debug.Log("ScreenExit");

			EventManager.TriggerEvent("GAME_EXIT");

			firstPlay = true;
            GameManager.Pause = false;
            //quando a tela termina de sair, desativa ela
            gameObject.SetActive(false);

			gameMain.Destroy();
        }
        /// <summary>
        /// Retart game
        /// </summary>
        public void RestartGame()
        {
            //fecha a tela do game over
            GameOverScreen.SetActive(false);
            //zera o score
            Score = 0;
            ScoreText.text = string.Format("{0:000}", Score);
            //
            firstPlay = true;
            gameOverGame = false;
            //despausa o jogo
            GameManager.Pause = false;
        }
        /// <summary>
        /// 
        /// </summary>
        public void OnGameOver()
        {
            //
            gameOverGame = true;
            //Time.timeScale = 0;
            GameManager.Pause = true;
            //mostra a tela de game over
            GameOverScreen.SetActive(true);
            //inicia a contagem de score
            GameOverScreen.GetComponent<GameOver>().ShowScore(Score);
        }
        /// <summary>
        /// 
        /// </summary>
        public void OnGameQuitOpen()
		{
			//UIButton backButton = GetComponent<UIButton>();
			//backButton.onClickNavigation.show.Add(new NavigationPointer("RunSheep", "TitleScreen"));
			//backButton.onClickNavigation.hide.Add(new NavigationPointer("RunSheep", "GameScreen"));

			Debug.Log(" OnGameQuitOpen");
            if (!gameOverGame)
            {
				QuitGame.SetActive(true);

				UIElement QuitGameUIElement = QuitGame.GetComponent<UIElement>();
				QuitGameUIElement.Show(false);

                //habilita a tela
                //Pausa o jogo
                GameManager.Pause = true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void OnQuitGameCancel()
        {
            //desabilita a tela
            //QuitGame.SetActive(false);
            //Despausa o jogo
            GameManager.Pause = false;
        }

		public void onReturnGame()
		{
			Debug.Log("onReturnGame");
			GameManager.Pause = false;
			firstPlay = true;

			ReturnGame.SetActive(false);
		}
		#endregion

		#region PRIVATE METHODS
		private void returnGame()
        {
            GameManager.Pause = true;
			UIElement ReturnGameUE = ReturnGame.GetComponent<UIElement>();
			//habilita a tela
			ReturnGame.SetActive(true);
			ReturnGameUE.Show(false);
        }
        #endregion
    }
}