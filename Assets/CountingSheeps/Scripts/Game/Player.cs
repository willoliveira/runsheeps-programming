using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class Player : MonoBehaviour
{
	public float MaxSpeed = 5f;
	public float JumpForce = 1000f;
	public Transform GroundCheck;

	private Game mGame;

	private bool Jump = false;
	private bool Grounded = false;
	private Animator anim;
	private Rigidbody2D mRigidbody2D;

	private int Score = 0;


	// Use this for initialization
	void Awake()
	{
		mGame = GameObject.Find("GameManager").GetComponent<Game>();
		mRigidbody2D = GetComponent<Rigidbody2D>();
	}

	public void JumpAction()
	{
		Grounded = Physics2D.Linecast(transform.position, GroundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		if (Grounded)
		{
			Jump = true;
		}
	}

	// Update is called once per frame
	//void Update()
	//{
	//	Grounded = Physics2D.Linecast(transform.position, GroundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
	//	if (Input.GetButtonDown("Jump") && Grounded)
	//	{
	//		Jump = true;
	//	}
	//}

	void FixedUpdate()
	{
		mRigidbody2D.velocity = new Vector2(MaxSpeed, mRigidbody2D.velocity.y);
		if (Jump)
		{
			mRigidbody2D.AddForce(new Vector2(0f, JumpForce));
			Jump = false;
		}
	}


	private void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Wall")
		{
			//mGame.OnGameOver();
		}

		if (coll.gameObject.tag == "DiscardSheep")
		{
			Destroy(transform.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "ScorePoint")
		{
			//mGame.OnScorePoint();
		}
	}
}