using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UserData
{
    public static int CurrentLevelId
    {
        get => PlayerPrefs.GetInt("CurrentLevelId", 0);

        set
        {
            PlayerPrefs.SetInt("CurrentLevelId", value);
        }
    }
    public static int MainLevelId
    {
        get => PlayerPrefs.GetInt("MainLevelId", 0);

        set
        {
            PlayerPrefs.SetInt("MainLevelId", value);
        }
    }
}
