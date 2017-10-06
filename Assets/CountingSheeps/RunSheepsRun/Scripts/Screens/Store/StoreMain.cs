using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace CountingSheeps.RunSheepsRun
{
	public class StoreMain : MonoBehaviour
	{
		[Tooltip("Lista de personagens - Por enquanto vai ficar aqui")]
		public List<CharacterDefinition> ListCharacters = new List<CharacterDefinition>();

		[Tooltip("Card-item do slider")]
		public GameObject SlideCard;

		[Tooltip("Container do slider")]
		public GameObject ScrollRect;

		[Tooltip("Botão de compra de personagem")]
		public GameObject BtSelecionarComprar;

		[Tooltip("Texto do saldo")]
		public Text TextSaldoCoins;

		private int currentChar = 0;

		private void Start()
		{

		}
		/// <summary>
		/// 
		/// </summary>
		public void Init()
		{
			GameManager.ListCharacters = ListCharacters;

			ScrollRect.SetActive(true);

			//coloca o saldo de moedas na tela da Store
			TextSaldoCoins.text = GameManager.Coins.ToString();
			//Cria os scroll com base nos personagens do config
			CreateScrollSnap();

			ConfigureSelectCharacter();
			//Eventos do scroll snap
			EventManager.StartListening("PREV", prevCharacter);
			EventManager.StartListening("NEXT", nextCharacter);
		}

		public void Destroy()
		{
			ScrollRect.SetActive(false);
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
				BtSelecionarComprar.GetComponentInChildren<Text>().text = "Selecionado";
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
				TextSaldoCoins.text = GameManager.Coins.ToString();
				//TODO: Localizar depois
				BtSelecionarComprar.GetComponentInChildren<Text>().text = "Selecionado";
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
		private void prevCharacter()
		{
			currentChar -= 1;
			if (currentChar < 0)
				currentChar = GameManager.ListCharacters.Count - 1;

			ConfigureSelectCharacter();
		}
		/// <summary>
		/// 
		/// </summary>
		private void nextCharacter()
		{
			currentChar += 1;
			if (currentChar >= GameManager.ListCharacters.Count)
				currentChar = 0;

			ConfigureSelectCharacter();
		}

		/// <summary>
		/// 
		/// </summary>
		private void ConfigureSelectCharacter()
		{
			Text btText = BtSelecionarComprar.GetComponentInChildren<Text>();
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

		/// <summary>
		/// 
		/// </summary>
		private void CreateScrollSnap()
		{
			GameObject ContainerSlides = ScrollRect.GetComponentsInChildren<GameObject>().ElementAt<GameObject>(0);
			//Debug.Log(config.ListCharacters.Count);
			//TODO: Tentar fazer esse sort de novo depois
			//listChars.Sort((a, b) => a.order);
			for (int cont = 0; cont < GameManager.ListCharacters.Count; cont++)
			{
				//cria uma instancia do slide
				GameObject instance = Instantiate(SlideCard) as GameObject;
				//Atribui no container
				instance.transform.SetParent(ContainerSlides.transform);
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
}