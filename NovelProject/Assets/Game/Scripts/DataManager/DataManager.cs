using System.Collections;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms;
using UnityEngine;
using System;
using Fungus;
using NetworkSync;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public static UserData userData;   
    public static Progress progress = new Progress();   

    public bool UserLogged
    {
        get { return (userLogged == 1); }
        set
        {
            userLogged = value ? 1 : 0;
            //SaveRegistered();
        }
    }

    private int userLogged = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        if (Instance != this)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
        PlayerPrefs.DeleteAll();
    }

    void Start()
    {
    }

    public void StartLogin()
    {
        MainMenu.Instance.ShowLoginPanel();
    }

    public void StartGameProcess()
    {
        MainMenu.Instance.ShowGamePanel();
    }

    private void AddStat(UInt32 score, ref uint average, ref uint max, ref uint total, uint divider)
    {
        total += score;
        average = total / divider;

        if (score > max)
        {
            max = score;
        }
    }

    public void AddScore(UInt32 score)
    {
    }

    public void CreateUser()
    {
        NetworkDataManager.Instance.UploadUserData(userData);
    }

    public void GetUser()
    {
        NetworkDataManager.Instance.GetUserDataID(userData);
    }

    public void WriteLocalProgress()
    {
    }

    public void ReadLocalProgress()
    {
    }
    
    public void WriteProgressToServer()
    {
        progress.data = JsonUtility.ToJson(SaveManager.SaveHistory);
        Debug.Log("ToServerProgress.data : " + progress.data);
        SaveManager.SaveHistory = JsonUtility.FromJson<SaveHistory>(progress.data);
        Debug.Log(SaveManager.SaveHistory);
        NetworkDataManager.Instance.UploadProgress(progress);
    }

    public void ReadProgressFromServer()
    {
        NetworkDataManager.Instance.DownloadProgress();
    }

    private bool IsRegistered()
    {
        if (PlayerPrefs.HasKey("userReg"))
        {
            userLogged = PlayerPrefs.GetInt("userReg");
            if (userLogged == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            userLogged = 0;
            return false;
        }
    }

    private void SaveRegistered()
    {
        PlayerPrefs.SetInt("userReg", userLogged);
        PlayerPrefs.Save();
    }

}
