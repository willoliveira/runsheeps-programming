using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class StoreScreen : MonoBehaviour {

	public List<CharacterDefinition> listChars;
	public GameObject slideChar;
	public GameObject containerSlides;

	public Config configFile;

	private int currentChar = 0;

	// Use this for initialization
	void Start ()
	{
		CreateScrollSnap();

		EventManager.StartListening("PREV", prevCharacter);
		EventManager.StartListening("NEXT", nextCharacter);
	}

	void prevCharacter()
	{
		Debug.Log("prevCharacter");
		currentChar -= 1;
		if (currentChar < 0)
			currentChar = listChars.Count - 1;
	}

	void nextCharacter()
	{
		Debug.Log("nextCharacter");
		currentChar += 1;
		if (currentChar >= listChars.Count)
			currentChar = 0;
	}

	void CreateScrollSnap()
	{
		Debug.Log(listChars.Count);
		//listChars.Sort((a, b) => a.order);
		for (int cont = 0; cont < listChars.Count; cont++)
		{
			//cria uma instancia do slide
			GameObject instance = Instantiate<GameObject>(slideChar) as GameObject;
			//Atribui no container
			instance.transform.SetParent(containerSlides.transform);
			//seta o texto no container
			instance.transform.Find("NameChar").GetComponent<Text>().text = listChars[cont].nameCharacter;
			//seta a imagem no container
			var imgChar = listChars[cont].image;
			instance.transform.Find("ImgChar").GetComponent<Image>().sprite = Sprite.Create(
				listChars[cont].image, 
				new Rect(new Vector2(0f, 0f), 
				new Vector2(imgChar.width, imgChar.height)), new Vector2(0, 0)
			);

			//listChars[cont].isAvaliable = true;
		}

	}

	public void SelectCharacter()
	{
		configFile.CharacterSelect = listChars.ElementAt(currentChar);
	}

	
	public void ScreenOpen()
	{
		//seta e tela atual
		GameManager.CurrentScreen = Screens.Store;
	}

	public void ScreenExit()
	{
		gameObject.SetActive(false);
	}





}
