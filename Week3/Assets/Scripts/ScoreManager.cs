using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*--------------------------------------------------------------------------------------*/
/*																						*/
/*	ScoreManager: Sets and saves the score of the game		     						*/
/*			Functions:																	*/
/*					public:																*/
/*						string FloatToTime(flaot toConvert, string format)             	*/
/*					proteceted:															*/
/*                                                                                      */
/*					private:															*/
/*						void Start ()													*/
/*																						*/
/*--------------------------------------------------------------------------------------*/
public class ScoreManager : MonoBehaviour 
{
    //  Static variables
	public static ScoreManager instance;

    //  Private variables with properties
	private const string PREF_HIGH_SCORE = "highScorePref";         //  Reference to player's high score in PlayerPrefs

	[SerializeField]
	private float score;                                            //  Player's current score
	public float Score                                              //  Properties of score
    {
		get
        {
			return score;	
		}

		set
        {
			score = value;

			if(score > HighScore)
            {
				HighScore = score;
			}
		}
	}

	private float highScore = 0.0f;                                 //  Player's highScore
	public float HighScore                                          //  Properties of highScore
    {
		get
        {
			highScore = PlayerPrefs.GetFloat(PREF_HIGH_SCORE);
			return highScore;
		}

		set
        {
			Debug.Log("Confetti!!!");
			highScore = value;
			
			PlayerPrefs.SetFloat(PREF_HIGH_SCORE, highScore);
		}
	}

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
			Destroy(gameObject);
		}
	}

    /*--------------------------------------------------------------------------------------*/
    /*																						*/
    /*	FloatToTime: Turns float into a readable string                            			*/
    /*		param: float toConvert - the float you're converting						    */
    /*			   string format - the format to convert to									*/
    /*																						*/
    /*		return: the formatted string 													*/
    /*																						*/
    /*--------------------------------------------------------------------------------------*/
	public string FloatToTime (float toConvert, string format)
    {
         switch (format)
         {
             case "00.0":
                        return string.Format("{0:00}:{1:0}", 
                            Mathf.Floor(toConvert) % 60,//seconds
                            Mathf.Floor((toConvert*10) % 10));//miliseconds
                        break;
             case "#0.0":
                        return string.Format("{0:#0}:{1:0}", 
                            Mathf.Floor(toConvert) % 60,//seconds
                            Mathf.Floor((toConvert*10) % 10));//miliseconds
                        break;
             case "00.00":
                        return string.Format("{0:00}:{1:00}", 
                            Mathf.Floor(toConvert) % 60,//seconds
                            Mathf.Floor((toConvert*100) % 100));//miliseconds
                        break;
             case "00.000":
                        return string.Format("{0:00}:{1:000}", 
                            Mathf.Floor(toConvert) % 60,//seconds
                            Mathf.Floor((toConvert*1000) % 1000));//miliseconds
                        break;
             case "#00.000":
                        return string.Format("{0:#00}:{1:000}", 
                            Mathf.Floor(toConvert) % 60,//seconds
                            Mathf.Floor((toConvert*1000) % 1000));//miliseconds
                        break;
             case "#0:00":
                        return string.Format("{0:#0}:{1:00}",
                            Mathf.Floor(toConvert / 60),//minutes
                            Mathf.Floor(toConvert) % 60);//seconds
                        break;
             case "#00:00":
                        return string.Format("{0:#00}:{1:00}", 
                            Mathf.Floor(toConvert / 60),//minutes
                            Mathf.Floor(toConvert) % 60);//seconds
                        break;
             case "0:00.0":
                        return string.Format("{0:0}:{1:00}.{2:0}",
                            Mathf.Floor(toConvert / 60),//minutes
                            Mathf.Floor(toConvert) % 60,//seconds
                            Mathf.Floor((toConvert*10) % 10));//miliseconds
                        break;
             case "#0:00.0":
                        return string.Format("{0:#0}:{1:00}.{2:0}",
                            Mathf.Floor(toConvert / 60),//minutes
                            Mathf.Floor(toConvert) % 60,//seconds
                            Mathf.Floor((toConvert*10) % 10));//miliseconds
                        break;
             case "0:00.00":
                        return string.Format("{0:0}:{1:00}.{2:00}",
                            Mathf.Floor(toConvert / 60),//minutes
                            Mathf.Floor(toConvert) % 60,//seconds
                            Mathf.Floor((toConvert*100) % 100));//miliseconds
                        break;
             case "#0:00.00":
                        return string.Format("{0:#0}:{1:00}.{2:00}",
                            Mathf.Floor(toConvert / 60),//minutes
                            Mathf.Floor(toConvert) % 60,//seconds
                            Mathf.Floor((toConvert*100) % 100));//miliseconds
                        break;
             case "0:00.000":
                        return string.Format("{0:0}:{1:00}.{2:000}",
                            Mathf.Floor(toConvert / 60),//minutes
                            Mathf.Floor(toConvert) % 60,//seconds
                            Mathf.Floor((toConvert*1000) % 1000));//miliseconds
                        break;
             case "#0:00.000":
                        return string.Format("{0:#0}:{1:00}.{2:000}",
                            Mathf.Floor(toConvert / 60),//minutes
                            Mathf.Floor(toConvert) % 60,//seconds
                            Mathf.Floor((toConvert*1000) % 1000));//miliseconds
                        break;
         }
         return "error";
    }
}