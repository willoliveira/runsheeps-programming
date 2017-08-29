using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class StoreScreen : MonoBehaviour {
	
	public GameObject slideChar;
	public GameObject containerSlides;
	public GameObject btSelecionarComprar;
	public Text txtSaldoCoins;

	private int currentChar = 0;

	// Use this for initialization
	void Start ()
	{
		//coloca o saldo de moedas na tela da Store
		txtSaldoCoins.text = GameManager.Coins.ToString();
		//Cria os scroll com base nos personagens do config
		CreateScrollSnap();

		ConfigureSelectCharacter();
		//Eventos do scroll snap
		EventManager.StartListening("PREV", prevCharacter);
		EventManager.StartListening("NEXT", nextCharacter);
	}

	/// <summary>
	/// Seleciona ou compra o personagem
	/// </summary>
	public void SelectCharacter()
	{
		//se o personagem já estiver disponivel
		if (GameManager.ListCharacters.ElementAt(currentChar).isAvaliable)
		{
			GameManager.CharacterSelect = GameManager.ListCharacters.ElementAt(currentChar);
			//TODO: Localizar depois
			btSelecionarComprar.GetComponentInChildren<Text>().text = "Selecionado";
		}
		//Se não, tenta comprar
		else if (GameManager.Coins >= GameManager.ListCharacters.ElementAt(currentChar).price)
		{
			//Seleciona o personagem
			GameManager.CharacterSelect = GameManager.ListCharacters.ElementAt(currentChar);
			//Depois da venda, coloca ele como disponivel para uso
			GameManager.CharacterSelect.isAvaliable = true;
			//Subtrai as moedas
			GameManager.Coins -= GameManager.ListCharacters.ElementAt(currentChar).price;
			//Atualiza o sando na tela
			txtSaldoCoins.text = GameManager.Coins.ToString();
			//TODO: Localizar depois
			btSelecionarComprar.GetComponentInChildren<Text>().text = "Selecionado";
		}
		//Não tem dinheiro!
		else
		{
			//TODO: Fazer um lance de vender moedas para o jogador (Unity IAP)
		}
		//Salvando
		//GameManager.GameData.coins = GameManager.Config.coins;
		//GameManager.GameData.characterSelect = GameManager.Config.CharacterSelect.nameCharacter;
		//GameManager.GameData.listCharacters = GameManager.Config.ListCharacters;

		//DataPersist.Save<GameData>(GameManager.GameData);

		//PlayerPrefs.SetString("CharacterSelect", GameManager.Config.CharacterSelect.nameCharacter);
		//PlayerPrefs.SetInt("Coins", GameManager.Config.coins);
	}
	/// <summary>
	/// 
	/// </summary>
	public void ScreenOpen()
	{
		//seta e tela atual
		GameManager.CurrentScreen = Screens.Store;
	}
	/// <summary>
	/// 
	/// </summary>
	public void ScreenExit()
	{
		gameObject.SetActive(false);
	}
	/// <summary>
	/// 
	/// </summary>
	private void prevCharacter()
	{
		currentChar -= 1;
		if (currentChar < 0)
			currentChar = GameManager.ListCharacters.Count - 1;

		ConfigureSelectCharacter();
	}

	private void nextCharacter()
	{
		currentChar += 1;
		if (currentChar >= GameManager.ListCharacters.Count)
			currentChar = 0;

		ConfigureSelectCharacter();
	}


	private void ConfigureSelectCharacter()
	{
		Text btText = btSelecionarComprar.GetComponentInChildren<Text>();
		//GameManager.Config.ListCharacters[];
		if (GameManager.CharacterSelect == GameManager.ListCharacters.ElementAt(currentChar))
		{
			btText.text = "Selecionado";
		}
		else if (GameManager.ListCharacters.ElementAt(currentChar).isAvaliable)
		{
			btText.text = "Selecionar";
		} 
		else
		{
			btText.text = "" + GameManager.ListCharacters.ElementAt(currentChar).price;
		}
	}


	private void CreateScrollSnap()
	{
		//Debug.Log(config.ListCharacters.Count);
		//TODO: Tentar fazer esse sort de novo depois
		//listChars.Sort((a, b) => a.order);
		for (int cont = 0; cont < GameManager.ListCharacters.Count; cont++)
		{
			//cria uma instancia do slide
			GameObject instance = Instantiate(slideChar) as GameObject;
			//Atribui no container
			instance.transform.SetParent(containerSlides.transform);
			//seta o texto no container
			instance.transform.Find("NameChar").GetComponent<Text>().text = GameManager.ListCharacters[cont].nameCharacter;
			//seta a imagem no container
			var imgChar = GameManager.ListCharacters[cont].image;
			instance.transform.Find("ImgChar").GetComponent<Image>().sprite = Sprite.Create(
				GameManager.ListCharacters[cont].image, 
				new Rect(new Vector2(0f, 0f), 
				new Vector2(imgChar.width, imgChar.height)), new Vector2(0, 0)
			);
		}

	}

}
