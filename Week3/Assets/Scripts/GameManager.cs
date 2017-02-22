using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

/*--------------------------------------------------------------------------------------*/
/*																						*/
/*	GameManager: Manages state of the game 		     									*/
/*			Functions:																	*/
/*					public:																*/
/*						                        										*/
/*					proteceted:															*/
/*                                                                                      */
/*					private:															*/
/*						void Start ()													*/
/*						void Update ()													*/
/*																						*/
/*--------------------------------------------------------------------------------------*/
public class GameManager : MonoBehaviour 
{
	//	Static Varibales
	public static GameManager instance;				//	This instance of Game Manager

	//	Public variables
	public string playerName = "AAA";
	public KeyCode restartLevel = KeyCode.Return;	//	Restarts level at the YOUWIN scene
	public PlayerController player;					//	Reference to player objetcs for health
	public DangerSquare dangerSquare;				//	Reference to danger square for speed
	public GameObject[] boundaries;					//	Holds the position of our boundaries 0 = top; 1 = right; 2 = bottom; 3 = left;

    /*--------------------------------------------------------------------------------------*/
    /*																						*/
    /*	Start: Runs once at the begining of the game. Initalizes variables.					*/
    /*																						*/
    /*--------------------------------------------------------------------------------------*/
	private void Start () 
	{
		//	A Singleton
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(this);
		}
		else
		{
			Destroy(this.gameObject);
		}

		boundaries = GameObject.FindGameObjectsWithTag("Boundary");
		
	}
    /*--------------------------------------------------------------------------------------*/
    /*																						*/
    /*	Update: Called once per frame														*/
    /*																						*/
    /*--------------------------------------------------------------------------------------*/
	private void Update () 
	{
		if (player == null)
		{
			//	Reference to player for GameManager
			player = GameObject.Find("Player1").GetComponent<PlayerController>();
		}

		if (dangerSquare == null)
		{
			//	Reference to danger square for GameManager
			dangerSquare = GameObject.Find("DangerSquare").GetComponent<DangerSquare>();
		}

		ScoreManager.instance.Score += Time.deltaTime;
		Debug.Log(ScoreManager.instance.Score);

		//	Restarts level if health is 0
		if(player.Health == 0)
		{
			FileIOScript.instance.SaveHighScore(playerName, ScoreManager.instance.FloatToTime(ScoreManager.instance.Score, "0:00.00"));
			ScoreManager.instance.Score = 0;
        	SceneManager.LoadScene("GameScene1",LoadSceneMode.Single);
		}

		//	Loads next level if Danger Sqaure reaches maximum speed
		if (dangerSquare.MoveSpeedX > dangerSquare.MAX_SPEED || dangerSquare.MoveSpeedY > dangerSquare.MAX_SPEED)
		{
			//	If first scene, load seconds scene, otherwise YOU WIN!!! NICE!
			if (SceneManager.GetActiveScene().name == "GameScene1")
			{
				SceneManager.LoadScene("GameScene2",LoadSceneMode.Single);
			}
			else
			{
				FileIOScript.instance.SaveHighScore(playerName, ScoreManager.instance.FloatToTime(ScoreManager.instance.Score, "0:00.00"));
				ScoreManager.instance.Score = 0;
				SceneManager.LoadScene("YOUWIN",LoadSceneMode.Single);
			}
		}

		//	Restart game when you press the restartLevel button
		if (SceneManager.GetActiveScene().name == "YOUWIN" && Input.GetKeyDown(restartLevel))
		{
			ScoreManager.instance.Score = 0;
			SceneManager.LoadScene("GameScene1",LoadSceneMode.Single);
		}
	}
}
