using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NetworkSync;

public class LoginMenu : MonoBehaviour
{

    public Text loginText;
    public Text passwordText;
    public Button loginButton;
    public Button regButton;
    public Toggle rememberMe;

    public void OnLogin()
    {
        DataManager.userData = new UserData
        {
            login = loginText.text,
            password = passwordText.text
        };
        SceneLoader.Instance.ScenePreload();
        DataManager.Instance.Login();
    }
}
