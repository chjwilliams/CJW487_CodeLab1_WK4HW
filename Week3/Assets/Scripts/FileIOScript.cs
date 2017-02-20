using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileIOScript : MonoBehaviour {
	public static FileIOScript instance;

	public const string FILE_NAME = "highScores.txt";

	public List<string> highScoreNames;
	public List<string> highScoreValues;

	private string finalFilePath;

	// Use this for initialization
	void Start () {
		
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

	public void SaveHighScore(string myName, string myScore)
	{	
		StreamWriter sw = new StreamWriter(finalFilePath, true);

		sw.WriteLine(myName + " " + myScore);
		sw.Close();
	}

	public void ReadHighScores()
	{
		StreamReader sr = new StreamReader(finalFilePath);

		int i = 0;

		while(!sr.EndOfStream){
			string line = sr.ReadLine();

			string[] splitLine = line.Split(' ');

			string name = splitLine[0];
			string value = splitLine[1];

			Debug.Log("name: " + name);
			Debug.Log("value: " + value);

			highScoreNames.Add(name);
			highScoreValues.Add(value);

			i++;
		}

		sr.Close();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}