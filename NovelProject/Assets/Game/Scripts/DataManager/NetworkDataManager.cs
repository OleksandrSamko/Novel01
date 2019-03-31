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

    private static string userCreatePath;
    private static string userGetPath;
    private static string progressPath;

    private void Awake()
    {
        Instance = this;
        basePath = "http://localhost/novel";
        userCreatePath = basePath + "/user/create.php";
        userGetPath = basePath + "/user/get.php";
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
        if (defRequest.Body != null)
        {
            Debug.Log("body: " + defRequest.Body.ToString());
        }
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

    public void UploadUserData(UserData data)
    {
        var postRequest = GetBasicRequest<UserData>(data, userCreatePath);

        RestClient.Post(postRequest)
        .Then(res =>
        {
            OnLoginSuccess(res);
        })
        .Catch(
            err =>
            {
                //no userID, no registered 
                Debug.LogWarning("Internet Error: " + err.Message);
                Message.Instance.ShowMessage("Internet Error: " + err.Message);
                DataManager.Instance.StartLogin();
                //DataManager.Instance.UserRegistered = false;
                //DataManager.Instance.LoadLocalProgress();
            }
        );
    }

    public void GetUserDataID(UserData data)
    {
        var getRequest = GetBasicRequest<UserData>(data, userGetPath);

        RestClient.Post(getRequest)
        .Then(res =>
        {
            OnLoginSuccess(res);
        })
        .Catch(
            err =>
            {
                //no userID, no registered 
                Debug.LogWarning("Internet Error: " + err.Message);
                Message.Instance.ShowMessage("Internet Error: " + err.Message);
                DataManager.Instance.StartLogin();
                //DataManager.Instance.UserRegistered = false;
                //DataManager.Instance.LoadLocalProgress();
            }
        );
    }

    private void OnLoginSuccess(ResponseHelper res)
    {
        Debug.Log("Succesful upload: " + res.Text);
        UserResponse userResponse;
        try
        {
            userResponse = JsonUtility.FromJson<UserResponse>(res.Text);
            if (userResponse.id == null || userResponse.id.Length < 1)
            {
                throw new ArgumentNullException(userResponse.id, "id is invalid");
            }
        }
        catch (Exception err)
        {
            Debug.LogWarning("Error: " + err.Message);
            Message.Instance.ShowMessage("Error: " + err.Message);
            DataManager.Instance.StartLogin();
            return;
        }
        //ok
        DataManager.userData.id = userResponse.id;
        Debug.Log("id=" + DataManager.userData.id);
        DataManager.Instance.UserRegistered = true;
        //DownloadProgress();
        DataManager.Instance.StartGameProcess();
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
