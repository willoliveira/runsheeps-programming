using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnChars : MonoBehaviour {

	#region PUBLIC VARS
	//tipos de personagens
	public GameObject[] Players;
	//Container onde será adicionados os personagens
	public GameObject Container;
	
	//tempo para criar as ovelhas
	public float TimeToSpawn = 0.6f;
	#endregion

	#region PRIVATE VARS
	private Game gameReference;
	//personagens que forem sendo criados
	private List<GameObject> ArrPlayers;
	//flag de inicio de jogo
	private bool flagInitGame = false;
	//tempo que for acumulando, para o spawn dos personagens
	private float TimeAmount = 0;

	private bool pauseBefore;
	private bool pauseLater;
	#endregion


	void Update()
	{
		//pauseBefore = GameManager.Pause;
		
		if (flagInitGame && !GameManager.Pause)
		{
			UpdateChars();

			TimeAmount += Time.deltaTime;

			if (TimeAmount >= TimeToSpawn)
			{
				OnSpawnChars();
				TimeAmount = 0;
			}
		}



		//pauseLater = GameManager.Pause;

		////assim que mudar o estado do pause
		//if (GameManager.Pause && pauseBefore != pauseLater)
		//{
			
		//}
		//else
		//{
		//	//volta a chamar os personagens
		//	InvokeRepeating("OnSpawnChars", 0, TimeToSpawn);
		//}
	}

	/// <summary>
	/// Inicializa a spawn sheeps
	/// </summary>
	public void InitGame(Game game)
	{
		gameReference = game;
		//inicia o array
		ArrPlayers = new List<GameObject>();
		//seta o inicio do jogo
		flagInitGame = true;
		//faz o respawn funcionar
		//InvokeRepeating("OnSpawnChars", 0, TimeToSpawn);
	}
	/// <summary>
	/// Limpa o personagens
	/// </summary>
	public void Clear()
	{
		foreach (Transform child in Container.transform)
		{
			Destroy(child.gameObject);
		}
		ArrPlayers.Clear();
	}
	/// <summary>
	/// Gera os personagens
	/// </summary>
	private void OnSpawnChars()
	{
		int RandomSheepIndex = (int) Random.Range(0, Players.Length);

		GameObject instanceChar = Instantiate(Players[RandomSheepIndex], transform.position, Quaternion.identity) as GameObject;
		instanceChar.transform.SetParent(Container.transform);

		instanceChar.GetComponent<Player>().mGame = gameReference;

		ArrPlayers.Add(instanceChar);
	}
	/// <summary>
	/// Metodo update
	/// </summary>
	void UpdateChars()
	{
		if (Input.GetButtonDown("Jump") || Input.touchCount > 0)
		{
			ArrPlayers[0].GetComponent<Player>().JumpAction();
		}
	}
	/// <summary>
	/// quando faz um ponto, remove um personagem do array que uso para armazenar os personagens gerados
	/// </summary>
	public void Scored()
	{
		ArrPlayers.RemoveAt(0);
	}
}
