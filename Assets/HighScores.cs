using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScores : MonoBehaviour
{
	string scoreInfo;
	public static HighScores Instance;

    
	void Awake()
    {
        if (Instance == null)                
            Instance = this;

        else if (Instance != this)
                
            Destroy(gameObject);                
    }

    public string AddEntry(float distance, string name)
	{
		int highScoreIndex = GetIndex(distance);

		if(highScoreIndex >= 0)
		{
			UpdateArrayValues (distance,name, highScoreIndex);
			scoreInfo = DataManager.Instance.distances[highScoreIndex].ToString() ;
		}
		return scoreInfo;						
	}

        int GetIndex(float distance)
	{		
		for (int i=0; i < DataManager.Instance.distances.Length ;i++)
		{
			if (distance > DataManager.Instance.distances[i])
			{
				return i;
			}
		}
		return -1;
	}

    
    
    void UpdateArrayValues (float distance,string name, int index)
	{
		for (int i=index; i < DataManager.Instance.distances.Length ;i++)
		{				
			float tempDistance = DataManager.Instance.distances[i];
			string tempName = DataManager.Instance.names[i];

			DataManager.Instance.distances[i] = distance;
			DataManager.Instance.names[i] = name;
				
			distance = tempDistance;
			name = tempName;
		}
	}

}
