using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class QuitGame : MonoBehaviour
{

	#region PUBLIC VARS
	public GameObject QuitScreen;
	#endregion

	#region PRIVATE VARS
	private bool QuitOpen;

	bool yetPaused = false;
	#endregion
	
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (!QuitScreen.activeSelf)
			{
				//if (Time.timeScale == 0)
				//{
				//	yetPaused = true;
				//}
				//else
				//{
				//	Time.timeScale = 0;
				//}

				GameManager.Pause = true;

				QuitScreen.SetActive(true);
			}
			else
			{
				Quit();
			}
		}
	}

	#region PUBLIC METHODS
	/// <summary>
	/// 
	/// </summary>
	public void OnButtonOk()
	{
		Quit();

		yetPaused = false;
	}
	/// <summary>
	/// 
	/// </summary>
	public void OnButtonCancel()
	{
		//if (!yetPaused)
		//	Time.timeScale = 1;

		GameManager.Pause = false;

		QuitScreen.SetActive(false);

		yetPaused = false;
	}
	#endregion

	#region PRIVATE METHODS
	/// <summary>
	/// 
	/// </summary>
	private void Quit()
	{
#if UNITY_EDITOR
		EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
	}
	#endregion

}
