using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour {

	public Text scoreText;
	public Text pointsText;
	public Text XPText;

	// Use this for initialization
	void Start () {
		
	}
	
	/// <summary>
	/// TODO: Colocar uma contagem do score depois
	/// </summary>
	/// <param name="score"></param>
	public void ShowScore (int score) {
		scoreText.text = string.Format("{0:000}", score);

		//meio gambs só pra testar
		pointsText.text = string.Format("{0:000}", score);
		XPText.text = string.Format("{0:000}", score);
	}
}
