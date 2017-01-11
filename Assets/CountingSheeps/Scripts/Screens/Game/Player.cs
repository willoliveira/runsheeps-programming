using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class Player : MonoBehaviour
{
	#region PUBLIC VARS
	//velocidade maxima dos personagens
	public float MaxSpeed = 5f;
	//força dos pulos
	public float JumpForce = 800f;
	//check do solo
	public Transform GroundCheck;
	//referencia de Game
	[HideInInspector]
	public Game mGame;
	#endregion

	#region PRIVATE VARS
	//se posso pular
	private bool Jump = false;
	//se estou no chao
	private bool Grounded = false;
	//referencia de Rigidbody
	private Rigidbody2D mRigidbody2D;
	//se o personagem passou pela zona de pontuação
	private bool CanDiscardChar = false;

	private CharacterDefinition CharacterProps;
	#endregion

	// Use this for initialization
	void Awake()
	{
		mRigidbody2D = GetComponent<Rigidbody2D>();
	}

	void Start()
	{
		InstantiatePlayer();
	}

	void FixedUpdate()
	{
		if (!GameManager.Pause)
		{
			//ficou meio gambs, depois tento fazer diferente
			mRigidbody2D.isKinematic = false;
			mRigidbody2D.velocity = new Vector2(MaxSpeed, mRigidbody2D.velocity.y);
			if (Jump)
			{
				mRigidbody2D.AddForce(new Vector2(0f, JumpForce));
				Jump = false;
			}
		}
		else
		{
			mRigidbody2D.isKinematic = true;
			mRigidbody2D.velocity = new Vector2(0, 0);
		}
	}
	
	void Update()
	{
		//verifica se o personagem esta tocando o chão
		Grounded = Physics2D.Linecast(transform.position, GroundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		//se tocar o chao e estiver passado pelo zona de score, marca um ponto
		if (Grounded && CanDiscardChar)
		{
			//destroi char
			Destroy(transform.gameObject);
			//gameObject.GetComponent<Animator>().SetTrigger("Destroy");
			CanDiscardChar = false;
		}
	}
	/// <summary>
	/// Acao de pular do personagem
	/// </summary>
	public void JumpAction()
	{
		//se estiver tocando o chao, pula!
		if (Grounded)
		{
			Jump = true;
		}
	}

	#region PRIVATE METHODS
	/// <summary>
	/// Inicializa um player com o valor no config
	/// </summary>
	private void InstantiatePlayer()
	{
		SpriteRenderer sRenderer = GetComponent<SpriteRenderer>();
		Texture2D characterSelect = GameManager.CharacterSelect.image;

		sRenderer.sprite = Sprite.Create(
			characterSelect,
			new Rect(new Vector2(0, 0), new Vector2(characterSelect.width, characterSelect.height)),
			new Vector2(0.5f, 0.5f)
		);
	}

	#region COLLIDERS
	/// <summary>
	/// Colider do player
	/// </summary>
	/// <param name="coll"></param>
	private void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Wall")
		{
			mGame.OnGameOver();
		}
	}
	/// <summary>
	/// Collider trigger da zona de score
	/// </summary>
	/// <param name="other"></param>
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "ScorePoint")
		{
			//avisa o game que o personagem já, colidiu com a zona de score
			mGame.OnScoreGoal();
		}
		else if (coll.gameObject.tag == "DiscardSheep")
		{
			//Seta o ponto
			mGame.OnScorePoint();
			//pode descartar o char
			CanDiscardChar = true;
		}
	}
	#endregion

	#endregion
}