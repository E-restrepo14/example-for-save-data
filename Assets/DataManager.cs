using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
 
    public static DataManager Instance;
    public float[] distances = new float[10]; 
	public string[] names = new string[10]; 
  
    
  void Awake()
    {
        if (Instance == null)                
            Instance = this;

        else if (Instance != this)
                
            Destroy(gameObject);                
    }

    
    public void ResetData()
    {
        distances = new float[10]; 
	    names = new string[10]; 
        Save();
    }

    
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/userData.dat");
        UserData data = new UserData();
        data.distances = distances;
        data.names = names;
        bf.Serialize(file, data);
        file.Close();

    }

    
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/userData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/userData.dat", FileMode.Open);
            UserData data = (UserData)bf.Deserialize(file);
            file.Close();
            distances = data.distances;
            names = data.names;
           if (names == null)
                names = new string[10];
            
            if (distances == null)
                distances = new float[10];

        }
        else
        {
            Save();
        }
    }
}