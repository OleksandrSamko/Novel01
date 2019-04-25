using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Config
{
    public static string home;
    public static string userCreatePath;
    public static string userGetPath;
    public static string progressGetPath;
    public static string progressSetPath;
    public static string saveDataKey;

    static Config()
    {
        home = "http://localhost/novel";
        userCreatePath = home + "/user/create.php";
        userGetPath = home + "/user/get.php";
        progressGetPath = home + "/progress/get.php";
        progressSetPath = home + "/progress/set.php";
        saveDataKey = "save_data";
    }
}
