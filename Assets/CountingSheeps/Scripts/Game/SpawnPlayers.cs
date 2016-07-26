using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnSheeps : MonoBehaviour {

	#region PUBLIC VARS
	public GameObject[] Sheeps;
	public GameObject SheepsContainer;

	public List<GameObject> ArrSheep;
	#endregion

	#region PRIVATE VARS
	private bool flagInitGame = false;

	private float TimeAmount = 0;
	private float TimeToSpawn = 0.6f;

	private int SheepCount = 0;
	#endregion

	public void InitGame()
	{
		flagInitGame = true;

		InvokeRepeating("SpawnSheep", 0, TimeToSpawn);
	}

	public void Clear()
	{
		ArrSheep.Clear();
	}

	private void SpawnSheep()
	{
		int RandomSheepIndex = (int) Random.Range(0, Sheeps.Length);

		GameObject instanceSheep = Instantiate(Sheeps[RandomSheepIndex], transform.position, Quaternion.identity) as GameObject;
		instanceSheep.transform.SetParent(SheepsContainer.transform);

		ArrSheep.Add(instanceSheep);
	}

	void Update()
	{
		//if (flagInitGame)
		//	UpdateSheeps();
	}

	void UpdateSheeps()
	{
		if (Input.GetButtonDown("Jump") || Input.touchCount > 0)
		{
			ArrSheep[0].GetComponent<Player>().JumpAction();
		}
	}

	public void SheepScore()
	{
		ArrSheep.RemoveAt(SheepCount);
		//SheepCount++;
	}
}
