using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour 
{
	public Text[] finalPositions;  


	void Start()
	{
		DataManager.Instance.Load();
		UpdateScores();
	}

	public void myAddEntryButton()
	{
		HighScores. Instance.AddEntry( Random.Range(0,666666),"Emanuel");			
	}

	public void UpdateScores()
	{	
		for (int i=0; i < 10 ;i++)
		{
			finalPositions[i].text =  DataManager.Instance.distances[i].ToString()+"....."+ DataManager.Instance.names[i];						
		}
		DataManager.Instance.Save();
	}

}
