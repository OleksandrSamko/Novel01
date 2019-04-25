using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using NetworkSync;

public class LocalDataManager : MonoBehaviour
{
    public static LocalDataManager Instance;
    public static string basePath;
    public static string progressPath;

    private void Awake()
    {
        Instance = this;
        basePath = Application.persistentDataPath;
        progressPath = basePath + "/save.json";
    }

    public static void Save<T>(T data, string savepath)
    {
        string jsonData = JsonUtility.ToJson(data);
        Debug.Log("SaveTo: " + savepath);
        Debug.Log("SaveData: " + jsonData);
        File.WriteAllText(savepath, jsonData);
    }

    public static T Load<T>(string loadpath)
    {
        T data = default(T);
        if (File.Exists(loadpath))
        {
            string jsonData = File.ReadAllText(loadpath);
            Debug.Log("LoadFrom: " + loadpath);
            data = JsonUtility.FromJson<T>(jsonData);
            Debug.Log("LoadData: " + data);
        }
        else
        {
            //no file
            Debug.Log("No file: " + loadpath);
        }
        return data;
    }

    public void SaveProgress(Progress progress)
    {
        Save<Progress>(progress, progressPath);
    }

    public Progress LoadProgress()
    {
        Progress data = Load<Progress>(progressPath);
        if (data == null)
        {
            data = new Progress();
            Debug.Log("new progress :" + data);
            SaveProgress(data);
        }
        return data;
    }
    
}
