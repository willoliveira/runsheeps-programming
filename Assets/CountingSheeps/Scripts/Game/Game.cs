using UnityEngine;
using UnityEngine.UI;
using System.Collections;


// TODO: FAZER UM METODO GENERICO PARA POP UP
// TODO: Pensar em um modo de fazer aquele lance de uma contagem pro jogo voltar a rodar, entao, deveria passar pelo menos lugar o pause do jogo, sei la
public class Game : MonoBehaviour {

	#region PUBLIC VARS
	public GameObject GameOverScreen;
	public GameObject QuitGame;

	public Text ScoreText;
	public GameObject spawnChars;
	#endregion

	#region PRIVATE VARS
	private SpawnChars mSpawnChars;
	private int Score = 0;
	#endregion


	void Start()
	{
		mSpawnChars = spawnChars.GetComponent<SpawnChars>();
	}

	#region PUBLIC METHODS
	/// <summary>
	/// 
	/// </summary>
	public void ScreenOpen()
	{
		//seta e tela atual
		GameManager.CurrentScreen = Screens.Game;
		//inicia o game
		Init();

		GameManager.Pause = false;
		//Debug.Log("Game ScreenOpen");
	}
	/// <summary>
	/// 
	/// </summary>
	public void ScreenExit()
	{
		//Debug.Log("Game ScreenExit");
		gameObject.SetActive(false);
		//Abre a proxima tela
	}
	
	/// <summary>
	/// 
	/// </summary>
	public void RestartGame()
	{
		//limpa os personagens da tela
		mSpawnChars.Clear();
		//fecha a tela do game over
		GameOverScreen.SetActive(false);
		//zera o score
		Score = 0;
		ScoreText.text = string.Format("{0:000}", Score);

		//Time.timeScale = 1;
		GameManager.Pause = false;
	}
	/// <summary>
	/// 
	/// </summary>
	public void OnGameOver()
	{
		//
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
		//habilita a tela
		QuitGame.SetActive(true);
		//Pausa o jogo
		GameManager.Pause = true;
	}
	/// <summary>
	/// 
	/// </summary>
	public void OnQuitGame()
	{
		//desabilita a tela
		QuitGame.SetActive(false);

		mSpawnChars.Clear();
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
		mSpawnChars.Scored();
	}

	public void OnScorePoint()
	{
		Score++;
		ScoreText.text = string.Format("{0:000}", Score);
	}
	#endregion


	#region PRIVATE METHODS
	/// <summary>
	/// 
	/// </summary>
	private void Init()
	{
		Debug.Log(mSpawnChars);
		mSpawnChars.InitGame(this);
	}
	#endregion
}
