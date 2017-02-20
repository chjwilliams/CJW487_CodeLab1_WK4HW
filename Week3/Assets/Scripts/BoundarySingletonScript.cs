
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundarySingletonScript : MonoBehaviour {

	public static BoundarySingletonScript instance;

	// Use this for initialization
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
