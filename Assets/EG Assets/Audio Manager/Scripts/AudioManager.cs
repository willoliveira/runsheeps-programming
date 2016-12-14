using UnityEngine;
using System.Collections;

public enum AudioType
{
	BGM,
	SFX
}
/// <summary>
/// Algumas funcionalidades fiz somente para BGM pois audios SFX geralmente são rapidos, conforme a necessidade construo metodos para ele tambem, são eles:
/// SetMuteAudio
/// SetPauseAudio
/// </summary>
public class AudioManager : MonoBehaviour
{
	#region PUBLIC VARS
	public static bool BGMEnable = true;
	public static bool SFXEnable = true;

	public GameObject BGMContainer;
	public GameObject SFXContainer;

	[HideInInspector]
	public static AudioManager instance
	{
		get
		{
			if (!audioManager)
			{
				Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
			}
			return audioManager;
		}
		set
		{
			audioManager = value;
		}
	}
	#endregion

	#region PRIVATE VARS
	private static AudioManager audioManager;

	private bool BGM_Before;
	private bool BGM_After;
	#endregion

	

	void Init()
	{
		//TODO: talvez começar a guardar audios em vetores, para uma maior controle dos audios adicionados em cena
	}

	void Awake()
	{
		//não deixa ele ser destruido
		DontDestroyOnLoad(gameObject);
		
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			DestroyObject(gameObject);
		}
	}

	void Update()
	{
#if UNITY_EDITOR

		BGM_Before = BGMEnable;
		//Se alterar o BGM pelo inspector
		if (BGM_Before != BGM_After)
		{
			SetMuteAudio(!BGMEnable, AudioType.BGM);
		}
		BGM_After = BGMEnable;
#endif
	}

	#region PUBLIC METHDOS
	/// <summary>
	/// 
	/// </summary>
	/// <param name="audio"></param>
	/// <param name="nameGameObject"></param>
	/// <param name="type"></param>
	public static void Play(AudioClip audio, string nameGameObject, AudioType type)
	{
		if (type == AudioType.BGM && BGMEnable || type == AudioType.SFX && SFXEnable)
		{
			instance.PlayAudio(audio, nameGameObject, type);
		}
		else
		{
			Debug.Log(string.Format("Tipo de audio {0} desativado!", type));
		}

	}
	/// <summary>
	/// 
	/// </summary>
	/// <param name="mute"></param>
	/// <param name="type"></param>
	public static void SetMuteAudio(bool mute, AudioType type)
	{
		if (type == AudioType.BGM)
		{
			instance.BGMContainer.GetComponent<AudioSource>().mute = mute;
			BGMEnable = !mute;
		}
		else if (type == AudioType.SFX)
		{
			SFXEnable = !mute;
		}

	}
	/// <summary>
	/// 
	/// </summary>
	/// <param name="pause"></param>
	/// <param name="type"></param>
	public static void SetPauseAudio(bool pause, AudioType type)
	{
		if (type == AudioType.BGM)
		{
			if (pause)
				instance.BGMContainer.GetComponent<AudioSource>().Pause();
			else
				instance.BGMContainer.GetComponent<AudioSource>().UnPause();
		}
		else
		{
			foreach (Transform sfx in instance.SFXContainer.transform)
			{
				if (pause)
					sfx.GetComponent<AudioSource>().Pause();
				else
					sfx.GetComponent<AudioSource>().UnPause();
			}
		}
	}
	/// <summary>
	/// 
	/// </summary>
	public static void Stop(string name, AudioType type)
	{
		GameObject audio = GameObject.Find(type + "-" + name);
		if (audio != null)
		{
			Destroy(audio);
		}
	}
	#endregion

	#region PRIVATE METHODS
	/// <summary>
	/// 
	/// </summary>
	/// <param name="audio"></param>
	/// <param name="nameGameObject"></param>
	/// <param name="type"></param>
	/// <returns></returns>
	private void PlayAudio(AudioClip audio, string nameGameObject, AudioType type)
	{
		//se for SFX
		if (type == AudioType.SFX)
		{
			StartCoroutine(CreateAudioSourceSFX(audio, nameGameObject, type));
		}
		//se for BGM
		else if (type == AudioType.BGM)
		{
			AudioSource BGMAudioSource = BGMContainer.GetComponent<AudioSource>();
			BGMAudioSource.name = type + "-" + nameGameObject;
			BGMAudioSource.clip = audio;
			BGMAudioSource.Play();

		}
	}
	/// <summary>
	/// 
	/// </summary>
	/// <param name="audio"></param>
	/// <param name="nameGameObject"></param>
	/// <param name="type"></param>
	/// <returns></returns>
	private IEnumerator CreateAudioSourceSFX(AudioClip audio, string nameGameObject, AudioType type)
	{
		//instancia um sfx
		GameObject instance = new GameObject(type + "-" + nameGameObject);
		instance.transform.SetParent(SFXContainer.transform);
		//adiciona e guarda um cache de audio source
		instance.AddComponent<AudioSource>();
		AudioSource instanceAudioSource = instance.AddComponent<AudioSource>();
		//coloca o som e executa ele
		instanceAudioSource.clip = audio;
		instanceAudioSource.Play();
		//coloca ele dentro do container de sfx
		instance.transform.SetParent(SFXContainer.transform);
		yield return new WaitForSeconds(audio.length);
		Destroy(instance.gameObject);
	}

	#endregion
}
