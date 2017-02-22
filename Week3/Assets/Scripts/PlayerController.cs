using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*--------------------------------------------------------------------------------------*/
/*																						*/
/*	PlayerController: Controls player 			     									*/
/*			Functions:																	*/
/*					public:																*/
/*						                        										*/
/*					proteceted:															*/
/*                                                                                      */
/*					private:															*/
/*						void Start ()													*/
/*						void Move (KeyCode key)											*/
/*						void CheckBoundary ()											*/
/*						void OnCollisionEnter2D (Collider2D other)						*/
/*						void Update ()													*/
/*																						*/
/*--------------------------------------------------------------------------------------*/
public class PlayerController : MonoBehaviour 
{
	//	Constatnt Variables... okay
	public const int MAX_HEALTH = 4;			//	Maximum amount of health a player can have

	//	Static Variables
	public SpriteRenderer spriteRenderer;		//	Reference to sprite renderer for players
	public TrailRenderer trail;					//	Reference to trail renderer for players	

	//	Public variables
	public float moveSpeed = 5.0f;				//	How fast the player moves
	public KeyCode upKey = KeyCode.W;			//	Input for moving up
	public KeyCode downKey = KeyCode.S;			//	Input for moving down
	public KeyCode rightKey = KeyCode.D;		//	Input for moving right
	public KeyCode leftKey = KeyCode.A;			//	Input for moving left

	//	Private variables
	[SerializeField]
	private static int health;					//	Health shared by all players
	public int Health 							//	Properties for health variable
	{ 
		get 
		{ 
			return health;
		} 
		set 
		{	
			if (value < 0)
			{
				value = 0;
			}
		}
	}

    /*--------------------------------------------------------------------------------------*/
    /*																						*/
    /*	Start: Runs once at the begining of the game. Initalizes variables.					*/
    /*																						*/
    /*--------------------------------------------------------------------------------------*/
	private void Start () 
	{
		//	Sets health to MAX_HEALTH
		health = MAX_HEALTH;

		//	Sets up reference to Sprite Renderer for ease of access when changing transparency
		spriteRenderer = GetComponent<SpriteRenderer>();

		//	Sets up reference to TRail Renderer for eas of access when changing how long the trail is	
		trail = GetComponent<TrailRenderer>();
	}

    /*--------------------------------------------------------------------------------------*/
    /*																						*/
    /*	Move: Moves player left, right, up, and/or down based on input						*/
    /*		param: KeyCode key - the key that was pressed									*/
	/*																						*/
    /*--------------------------------------------------------------------------------------*/
	private void Move (KeyCode key)
	{
		if (Input.GetKey(upKey))
		{
			transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
		}
		else if (Input.GetKey(downKey))
		{
			transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
		}

		if (Input.GetKey(rightKey))
		{
			transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
		}
		else if (Input.GetKey(leftKey))
		{
			transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
		}

		CheckBoundary();
	}

	/*--------------------------------------------------------------------------------------*/
    /*																						*/
    /*	CheckBoundary: If player hits bounds reverse their motion							*/
    /*																						*/
    /*--------------------------------------------------------------------------------------*/
	private void CheckBoundary()
	{
		Vector3 newPosition = transform.position;
		if (transform.position.y > GameManager.instance.boundaries[1].transform.position.y)
		{
			newPosition = new Vector3( transform.position.x, GameManager.instance.boundaries[1].transform.position.y, transform.position.z);
		}
		else if (transform.position.y < GameManager.instance.boundaries[2].transform.position.y)
		{
			newPosition = new Vector3( transform.position.x, GameManager.instance.boundaries[2].transform.position.y, transform.position.z);
		}

		if (transform.position.x > GameManager.instance.boundaries[0].transform.position.x)
		{
			newPosition = new Vector3(GameManager.instance.boundaries[0].transform.position.x, transform.position.y ,transform.position.z);
		}
		else if (transform.position.x < GameManager.instance.boundaries[3].transform.position.x)
		{
			newPosition = new Vector3(GameManager.instance.boundaries[3].transform.position.x, transform.position.y ,transform.position.z);
		}

		transform.position = newPosition;
	}

	/*--------------------------------------------------------------------------------------*/
    /*																						*/
    /*	OnCollisionEnter2D: Called when collide with another colider						*/
	/*			param: Collider2D other - the thing we collided with						*/
	/*																						*/
    /*--------------------------------------------------------------------------------------*/
	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.name.Contains("Boundary"))
		{
			moveSpeed = -moveSpeed;
		}

		if (other.gameObject.name.Contains("Danger"))
		{	
			//	Lower health by 1
			health--;

			//	Get 25% more transparent
			spriteRenderer.color = new Color (spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, (float)health / MAX_HEALTH);
			
			//	Trail get 25% shorter
			trail.time = trail.time * (float)health / MAX_HEALTH;
		}
	}
	
	/*--------------------------------------------------------------------------------------*/
    /*																						*/
    /*	Update: Called once per frame														*/
    /*																						*/
    /*--------------------------------------------------------------------------------------*/
	private void Update () 
	{
		Move (upKey);
		Move (downKey);
		Move (leftKey);
		Move (rightKey);
	}
}
