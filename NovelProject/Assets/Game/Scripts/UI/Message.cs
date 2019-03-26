using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{
    public static Message Instance;
    [SerializeField]
    GameObject messagePanel;
    [SerializeField]
    Text messageText;
    //public static string text;

    private void Awake()
    {
        gameObject.SetActive(false);
        if (Instance == null)
            Instance = this;
        if (Instance != this)
            Destroy(this.gameObject);
    }

    public void ShowMessage(string text)
    {
        messageText.text = text;
        messagePanel.SetActive(true);
    }
   
}
