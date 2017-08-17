using UnityEngine;
using UnityEngine.UI;
using System.Collections;


// TODO: FAZER UM METODO GENERICO PARA POP UP
public class GameScreen : MonoBehaviour
{

	#region PUBLIC VARS
	public GameObject GameOverScreen;
	public GameObject QuitGame;
	public GameObject ReturnGame;
	public GameObject mCamera;

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
			StartCoroutine(returnGame());
		}
		else
		{
			firstPlay = false;
		}
		afterPause = GameManager.Pause;
	}

	#region PUBLIC METHODS
	/// <summary>
	/// Chamado com a janela é aberta
	/// </summary>
	public void ScreenOpen()
	{
		//quando reseta a jogada
		firstPlay = true;
		beforePause = false;
		afterPause = false;

		GameManager.Pause = false;

		//seta e tela atual
		GameManager.CurrentScreen = Screens.Game;
        //inicia o game
        gameMain.InitGame();
	}
	/// <summary>
	/// Chamado com a janela é fechada
	/// </summary>
	public void ScreenExit()
	{
		firstPlay = true;
		GameManager.Pause = false;
		//quando a tela termina de sair, desativa ela
		gameObject.SetActive(false);
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
		if (!gameOverGame)
		{
			//habilita a tela
			QuitGame.SetActive(true);
			//Pausa o jogo
			GameManager.Pause = true;
		}
	}
	/// <summary>
	/// 
	/// </summary>
	public void OnQuitGame()
	{
		//desabilita a tela
		QuitGame.SetActive(false);
	}
	/// <summary>
	/// 
	/// </summary>
	public void OnQuitGameCancel()
	{
		//desabilita a tela
		QuitGame.SetActive(false);
		//Despausa o jogo
		GameManager.Pause = false;
	}
	/// <summary>
	/// 
	/// </summary>
	public void OnScoreGoal()
	{

	}
	/// <summary>
	/// 
	/// </summary>
	public void OnScorePoint()
	{
		Score++;
		ScoreText.text = string.Format("{0:000}", Score);
	}
	#endregion

	#region PRIVATE METHODS
	private IEnumerator returnGame()
	{
		GameManager.Pause = true;
		//habilita a tela
		ReturnGame.SetActive(true);
		//chama a rotina que conta o tempo antes de voltar
		yield return StartCoroutine(ReturnGame.GetComponent<ReturnGame>().CountReturn());
		//habilita a tela
		ReturnGame.SetActive(false);
		//despausa o jogo
		GameManager.Pause = false;
		firstPlay = true;
	}
	#endregion
}
