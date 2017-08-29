using UnityEngine;
using System.Collections;

public class HideOnAwake : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		gameObject.SetActive(false);
	}
}
