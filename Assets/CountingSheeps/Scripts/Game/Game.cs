using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Game : MonoBehaviour {

	#region PUBLIC VARS
	public GameObject GameOverScreen;
	public Text ScoreText;
	public SpawnChars mSpawnChars;
	public GameObject SheepsContainer;
	#endregion

	#region PRIVATE VARS
	private int Score = 0;
	#endregion

	#region PUBLIC METHODS
	public void Init()
	{
		Debug.Log("Init");
	}
	public void ScreenExit()
	{
		Debug.Log("ScreenExit");
		gameObject.SetActive(false);
		//Abre a proxima tela
	}

	//public void RestartGame()
	//{
	//	foreach (Transform child in SheepsContainer.transform) {
	//		Destroy(child.gameObject);
	//	}
	//	//limpa o array das ovelhas
	//	mSpawnSheeps.Clear();
	//	//fecha a tela do game over
	//	GameOverScreen.SetActive(false);
	//	//zera o score
	//	Score = 0;
	//	ScoreText.text = string.Format("{0:000}", Score);
	//	Time.timeScale = 1;
	//}

	//public void OnGameOver()
	//{
	//	Time.timeScale = 0;
	//	GameOverScreen.SetActive(true);		
	//	ScoreText.text = string.Format("{0:000}", Score);
	//}

	//public void OnScorePoint()
	//{
	//	Score++;
	//	ScoreText.text = string.Format("{0:000}", Score);
	//	//
	//	mSpawnSheeps.SheepScore();
	//}
	#endregion
}
