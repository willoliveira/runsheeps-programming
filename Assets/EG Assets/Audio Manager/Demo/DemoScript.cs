using UnityEngine;
using System.Collections;

public class DemoScript : MonoBehaviour {

	public AudioClip BGMAudio;

	// Use this for initialization
	void Start () {
		AudioManager.Play(BGMAudio, "BGMGame", AudioType.BGM);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ToogleSFX()
	{
		AudioManager.SetMuteAudio(AudioManager.SFXEnable, AudioType.SFX);
	}

	public void ToogleBGM()
	{
		AudioManager.SetMuteAudio(AudioManager.BGMEnable, AudioType.BGM);
	}
}
