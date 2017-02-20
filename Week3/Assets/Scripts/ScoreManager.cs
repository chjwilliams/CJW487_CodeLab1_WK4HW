using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*--------------------------------------------------------------------------------------*/
/*																						*/
/*	ScoreManager: Sets and saves the score of the game		     						*/
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
public class ScoreManager : MonoBehaviour {

	private const string PREF_TEST_KEY = "test";
	private const string PREF_HIGH_SCORE = "highScorePref";

	[SerializeField]
	private float score;

	public float Score{
		get{
			return score;	
		}

		set{
			score = value;

			if(score > HighScore){
				HighScore = score;
			}
		}
	}

	private float highScore = 0.0f;

	public float HighScore{
		get{
			highScore = PlayerPrefs.GetFloat(PREF_HIGH_SCORE);
			return highScore;
		}

		set{
			Debug.Log("Confetti!!!");
			highScore = value;
			
			PlayerPrefs.SetFloat(PREF_HIGH_SCORE, highScore);
			
			
			
		}
	}

	public static ScoreManager instance;

	// Use this for initialization
	void Start () {
		
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

	public string FloatToTime (float toConvert, string format){
         switch (format){
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
	
	// Update is called once per frame
	void Update () 
	{
		 
		 //Debug.Log (FloatToTime(Score, "0:00.00"));
	}
}
