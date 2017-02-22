
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*--------------------------------------------------------------------------------------*/
/*																						*/
/*	BoundarySingletonScript: Singleton for the game's boundaries						*/
/*			Functions:																	*/
/*					public:																*/
/*																					    */
/*					proteceted:															*/
/*                                                                                      */
/*					private:															*/
/*						void Start ()													*/
/*																						*/
/*--------------------------------------------------------------------------------------*/
public class BoundarySingletonScript : MonoBehaviour 
{
	public static BoundarySingletonScript instance;			//	Instance of Boundary Script

	/*--------------------------------------------------------------------------------------*/
    /*																						*/
    /*	Start: Runs once at the begining of the game. Initalizes variables.					*/
    /*																						*/
    /*--------------------------------------------------------------------------------------*/
	void Start () 
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(this);
		}
		else
		{
			DestroyObject(gameObject);
		}	
	}
}
