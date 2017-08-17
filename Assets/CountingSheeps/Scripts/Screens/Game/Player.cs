﻿using UnityEngine;
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
	public GameScreen gameScreen;
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
        //refatorar esse cara depois
		//InstantiatePlayer();

        //mRigidbody2D.isKinematic = true;
    }

	void FixedUpdate()
	{
		if (GameManager.Pause)
        {
            mRigidbody2D.isKinematic = true;
            Animator anim = GetComponent<Animator>();
            anim.speed = 0;
        }
        else
        {
            Animator anim = GetComponent<Animator>();
            anim.speed = 1;

            mRigidbody2D.isKinematic = false;
			if (Jump)
			{
				mRigidbody2D.AddForce(new Vector2(0f, JumpForce));
				Jump = false;
			}
		}
	}
	
	void Update()
	{
		//verifica se o personagem esta tocando o chão
		Grounded = Physics2D.Linecast(transform.position, GroundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
	}
	/// <summary>
	/// Acao de pular do personagem
	/// </summary>
	public void JumpAction()
	{
		//se estiver tocando o chao, pula!
		if (GameManager.CurrentScreen == Screens.Game && Grounded)
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
			gameScreen.OnGameOver();
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
			gameScreen.OnScoreGoal();
		}
		else if (coll.gameObject.tag == "DiscardSheep")
		{
			//Seta o ponto
			gameScreen.OnScorePoint();
			//pode descartar o char
			CanDiscardChar = true;
		}
	}
	#endregion

	#endregion
}