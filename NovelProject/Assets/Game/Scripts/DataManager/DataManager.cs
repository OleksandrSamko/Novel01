using System.Collections;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms;
using UnityEngine;
using System;
using NetworkSync;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public static UserData userData;   
    public static Progress progress;   

    public bool UserRegistered
    {
        get { return (userRegistered == 1); }
        set
        {
            userRegistered = value ? 1 : 0;
            SaveRegistered();
        }
    }

    private int userRegistered = 0;

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

    public void SaveLocalProgress()
    {
    }

    public void LoadLocalProgress()
    {
    }
    
    public void LoadNetworkProgress()
    {
    }

    public void SaveNetworkProgress()
    {
    }

    private bool IsRegistered()
    {
        if (PlayerPrefs.HasKey("userReg"))
        {
            userRegistered = PlayerPrefs.GetInt("userReg");
            if (userRegistered == 1)
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
            userRegistered = 0;
            return false;
        }
    }

    private void SaveRegistered()
    {
        PlayerPrefs.SetInt("userReg", userRegistered);
        PlayerPrefs.Save();
    }

}
