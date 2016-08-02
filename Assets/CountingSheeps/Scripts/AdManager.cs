using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;

public class AdManager : MonoBehaviour {

	public string zoneId = "rewardedVideoZone";
	public int rewardQty = 250;

	void OnGUI()
	{
		if (string.IsNullOrEmpty(zoneId)) zoneId = null;

		Rect buttonRect = new Rect(10, 10, 150, 50);
		string buttonText = Advertisement.IsReady(zoneId) ? "Show Ad" : "Waiting...";

		ShowOptions options = new ShowOptions();
		options.resultCallback = HandleShowResult;

		if (GUI.Button(buttonRect, buttonText))
		{
			Advertisement.Show(zoneId, options);
		}
	}

	private void HandleShowResult(ShowResult result)
	{
		switch (result)
		{
			case ShowResult.Finished:
				Debug.Log("Video completed. User rewarded " + rewardQty + " credits.");
				break;
			case ShowResult.Skipped:
				Debug.LogWarning("Video was skipped.");
				break;
			case ShowResult.Failed:
				Debug.LogError("Video failed to show.");
				break;
		}
	}







	[SerializeField]
	string gameID = "1104151";

	void Awake()
	{
		Advertisement.Initialize(gameID, true);
	}
	
	public void ShowAd(string zone = "")
	{

		Debug.Log("teste");

//#if UNITY_EDITOR
//		StartCoroutine(WaitForAd());
//#endif

		if (string.Equals(zone, ""))
			zone = null;

		ShowOptions options = new ShowOptions();
		options.resultCallback = AdCallbackhandler;

		if (Advertisement.IsReady(zone))
		{
			Debug.Log("teste top");
			Advertisement.Show(zone, options);
			//Advertisement.Show();
		}
		//Advertisement.Show();
	}

	void AdCallbackhandler(ShowResult result)
	{
		switch (result)
		{
			case ShowResult.Finished:
				Debug.Log("Ad Finished. Rewarding player...");
				break;
			case ShowResult.Skipped:
				Debug.Log("Ad skipped. Son, I am dissapointed in you");
				break;
			case ShowResult.Failed:
				Debug.Log("I swear this has never happened to me before");
				break;
		}

		Debug.Log(ShowResult.Finished);
	}

	IEnumerator WaitForAd()
	{
		float currentTimeScale = Time.timeScale;
		Time.timeScale = 0f;
		yield return null;

		while (Advertisement.isShowing)
			yield return null;

		Time.timeScale = currentTimeScale;
	}
}
