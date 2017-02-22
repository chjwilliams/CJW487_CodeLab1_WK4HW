using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*--------------------------------------------------------------------------------------*/
/*																						*/
/*	DangerSquare: Controls DangerSquare			     									*/
/*			Functions:																	*/
/*					public:																*/
/*						                        										*/
/*					proteceted:															*/
/*                                                                                      */
/*					private:															*/
/*						void Start ()													*/
/*						void Move ()													*/
/*						void OnCollisionEnter2D (Collider2D other)						*/
/*						void Update ()													*/
/*																						*/
/*--------------------------------------------------------------------------------------*/
public class DangerSquare : MonoBehaviour 
{
	public const float _MAX_SPEED = 8;			//	Maximum speed the Danger Sqaure can go
	public float MAX_SPEED						//	Cannot access public const in other classes?
	{
		get 
		{ 
			return _MAX_SPEED;
		}
	}

	public float moveSpeedX = 1.0f;				//	How fast the Danger Square moves in the horizontal direction
	public float MoveSpeedX 					//	Properties for moveSpeedX
	{
		get 
		{	
			return moveSpeedX;
		}
		set
		{
			if (moveSpeedX > MAX_SPEED)
			{
				moveSpeedX = MAX_SPEED;
			}
		}
	}
	public float moveSpeedY = 1.0f;				//	How fast the Danger Square moves in the vertical direction
	public float MoveSpeedY 					//	Properties for moveSpeedY
	{
		get 
		{	
			return moveSpeedY;
		}
		set
		{
			if (moveSpeedY > MAX_SPEED)
			{
				moveSpeedY = MAX_SPEED;
			}
		}
	}
	public float speedIncrement = 1.5f;			//	How fast the Danger  square increments speed
	public float radius;						//	the bounds of the sprite
	
	/*--------------------------------------------------------------------------------------*/
    /*																						*/
    /*	Start: Runs once at the begining of the game. Initalizes variables.					*/
    /*																						*/
    /*--------------------------------------------------------------------------------------*/
	private void Start () 
	{
		//	Sets radius for DangerSquare
		radius = GetComponent<SpriteRenderer>().bounds.extents.x;
	}
	
	/*--------------------------------------------------------------------------------------*/
    /*																						*/
    /*	Move: Moves DangerSquare and changes direction when bounds are hit					*/
	/*																						*/
    /*--------------------------------------------------------------------------------------*/
	private void Move()
	{
		if (transform.position.y + radius > GameManager.instance.boundaries[1].transform.position.y - radius || 
			transform.position.y - radius < GameManager.instance.boundaries[2].transform.position.y + radius)
		{
			moveSpeedY = moveSpeedY * -1 * speedIncrement;			
		}

		if (transform.position.x + radius > GameManager.instance.boundaries[0].transform.position.x - radius || 
			transform.position.x - radius < GameManager.instance.boundaries[3].transform.position.x + radius)
		{
			moveSpeedX = moveSpeedX * -1 * speedIncrement;
		}

		//	How we move
		transform.Translate((Vector3.right * moveSpeedX + Vector3.up * moveSpeedY) * Time.deltaTime);
	}

	/*--------------------------------------------------------------------------------------*/
    /*																						*/
    /*	OnCollisionEnter2D: Called when collide with another colider						*/
	/*			param: Collider2D other - the thing we collided with						*/
	/*																						*/
    /*--------------------------------------------------------------------------------------*/
	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.name.Contains("Player"))
		{
			moveSpeedX = moveSpeedX * -1.0f;
			moveSpeedY = moveSpeedY * -1.0f;
		}
	}

	/*--------------------------------------------------------------------------------------*/
    /*																						*/
    /*	Update: Called once per frame														*/
    /*																						*/
    /*--------------------------------------------------------------------------------------*/
	private void Update () 
	{
		Move();
	}
}
