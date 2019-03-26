using UnityEngine;
using Proyecto26;
using RSG;
using System;
using UnityEngine.SocialPlatforms;
using System.Collections.Generic;
using System.Collections;
using NetworkSync;

public class NetworkDataManager : MonoBehaviour
{
    public static NetworkDataManager Instance;
    public static string basePath;

    private static string userPath;
    private static string progressPath;

    private void Awake()
    {
        Instance = this;
        basePath = "";
        userPath = basePath+"/player/create";
        progressPath = basePath + "";
    }

    static void UploadData<T>(T data, string uploadpath)
    {
        var postRequest = GetBasicRequest<T>(data, uploadpath);

        RestClient.Post<T>(postRequest)
        .Then(res =>
        {
            Debug.Log("Succesful upload: " + res);
        })
        .Catch(
            err =>
            {
                Debug.LogWarning("Internet Error: " + err.Message);
            }
        );
    }

    static RequestHelper GetBasicRequest<T>(T data, string path)
    {
        RestClient.DefaultRequestHeaders["Content-Type"] = "application/json";

        var defRequest = new RequestHelper
        {
            Uri = path,
            Body = data,
            Timeout = 10,
            Retries = 1,
            RetrySecondsDelay = 2,
            RetryCallback = (err, retries) =>
            {
                Debug.LogWarning("Retry error: " + err);
            },
            EnableDebug = true,
        };
        if (defRequest.Body != null) {
            Debug.Log("body: "+defRequest.Body.ToString());        }
        //Debug.Log("Content : "+RestClient.DefaultRequestHeaders["Content-Type"]);
        return defRequest;
    }

    static RequestHelper GetUIDRequest<T>(T data, string path)
    {
        //default request
        RestClient.DefaultRequestHeaders["Content-Type"] = "application/json";  
        RestClient.DefaultRequestHeaders["Authorization"] = DataManager.userData.id;

        var defRequest = new RequestHelper
        {
            Uri = path,
            Body = data,
            Timeout = 10,
            Retries = 1,
            RetrySecondsDelay = 2,
            RetryCallback = (err, retries) =>
            {
                Debug.LogWarning("Retry error: " + err);
            },
            EnableDebug = true,
        };
        if (defRequest.Body != null)
        {
            Debug.Log("uid body: " + defRequest.Body.ToString());
        }

        return defRequest;
    }

    public void UploadUserData( UserData data)
    {
        var postRequest = GetBasicRequest<UserData>(data, userPath);

        RestClient.Post<UserData>(postRequest)
        .Then(res =>
        {
            Debug.Log("Succesful upload: " + res);
            DataManager.userData.id = res.id;

            DataManager.Instance.UserRegistered = true;
            //DownloadProgress();
            DataManager.Instance.StartGameProcess();
        })
        .Catch(
            err =>
            {
                //no userID, no registered 
                Debug.LogWarning("Internet Error: " + err.Message);
                Message.Instance.ShowMessage("Internet Error: " + err.Message);
                //DataManager.Instance.UserRegistered = false;
                //DataManager.Instance.LoadLocalProgress();
                DataManager.Instance.StartGameProcess();
            }
        );
    }

    public void UploadProgress(Progress progress)
    {
        var postRequest = GetUIDRequest<Progress>(progress, progressPath);

        RestClient.Post<Progress>(postRequest)
        .Then(res =>
        {
            Debug.Log("Succesful upload answer: " + res);
        })
        .Catch(
            err =>
            {
                Debug.LogWarning("Internet Error: " + err.Message);
            }
        );
    }

    public void DownloadProgress()
    {
        var getRequest = GetUIDRequest<Progress>(null, progressPath);

        RestClient.Get(getRequest).Then(response =>
        {
            //got stats from server, save stats to device
            Debug.Log("response.Text " + response.Text);
            DataManager.progress = JsonUtility.FromJson<Progress>(response.Text);
            DataManager.Instance.SaveLocalProgress();
        })
        .Catch(
            err =>
            {
                //load local stats 
                Debug.LogWarning("Internet Error: " + err.Message);
                DataManager.Instance.LoadLocalProgress();
            }
        );
    }
    
}
