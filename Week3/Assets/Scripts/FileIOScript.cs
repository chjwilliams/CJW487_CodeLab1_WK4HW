using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/*--------------------------------------------------------------------------------------*/
/*																						*/
/*	FileIOScript: Manage file input/output	for myScore		     						*/
/*			Functions:																	*/
/*					public:																*/
/*						string SaveHighScore(string myName, string myScore)             */
/*						string ReadHighScores()								            */
/*					proteceted:															*/
/*                                                                                      */
/*					private:															*/
/*						void Start ()													*/
/*																						*/
/*--------------------------------------------------------------------------------------*/
public class FileIOScript : MonoBehaviour 
{
	public static FileIOScript instance;				//	Reference to the instance

	public const string FILE_NAME = "highScores.txt";	//	File names for highscores

	public List<string> highScoreNames;					//	List of high score names
	public List<string> highScoreValues;				//	List of high score values

	private string finalFilePath;						//	The final file path

	/*--------------------------------------------------------------------------------------*/
    /*																						*/
    /*	Start: Runs once at the begining of the game. Initalizes variables.					*/
    /*																						*/
    /*--------------------------------------------------------------------------------------*/
	void Start () 
	{	
		//	Sets up file path
		finalFilePath = Application.dataPath + "/" + FILE_NAME;

		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(this);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	/*--------------------------------------------------------------------------------------*/
    /*																						*/
    /*	SaveHighScore: Saves the highscore to a txt file									*/
    /*		param: string myName - the name of a player										*/
	/*			   string myScore - the player's score										*/
	/*																						*/
    /*--------------------------------------------------------------------------------------*/
	public void SaveHighScore(string myName, string myScore)
	{	
		StreamWriter sw = new StreamWriter(finalFilePath, true);

		sw.WriteLine(myName + " " + myScore);
		sw.Close();
	}

	public void ReadHighScores()
	{
		// To Be Written
	}
}