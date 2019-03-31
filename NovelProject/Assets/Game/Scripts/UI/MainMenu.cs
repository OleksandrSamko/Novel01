using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NetworkSync;

public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance;

    public Transform loginPanel;
    public Transform userPanel;
    public Text loginText;
    public Text passwordText;
    public Button loginButton;
    public Button regButton;
    public Toggle rememberMe;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        if (Instance != this)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }


    public void OnCreateUser()
    {
        DataManager.userData = new UserData
        {
            login = loginText.text,
            password = passwordText.text
        };
        SceneLoader.Instance.ScenePreload();
        DataManager.Instance.CreateUser();
    }

    public void OnGetUser()
    {
        DataManager.userData = new UserData
        {
            login = loginText.text,
            password = passwordText.text
        };
        SceneLoader.Instance.ScenePreload();
        DataManager.Instance.GetUser();
    }

    public void ShowLoginPanel()
    {
        SceneLoader.Instance.ScenePreloadDisable();
        loginPanel.gameObject.SetActive(true);
        userPanel.gameObject.SetActive(false);
    }

    public void ShowGamePanel()
    {
        SceneLoader.Instance.ScenePreloadDisable();
        loginPanel.gameObject.SetActive(false);
        userPanel.gameObject.SetActive(true);
    }
}
