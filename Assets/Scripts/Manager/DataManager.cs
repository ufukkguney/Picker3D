using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : CustomBehaviour
{
    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);
        CheckIsAllLevelsFinish();
        GameManager.EventManager.OnLevelFinish += LevelDone;
    }
    private void OnDestroy()
    {
        GameManager.EventManager.OnLevelFinish += LevelDone;
    }

    private void LevelDone()
    {
        Debug.Log("before level ID : " + UserData.CurrentLevelId);
        UserData.CurrentLevelId++;
        UserData.MainLevelId++;
        Debug.Log("after level ID : " + UserData.CurrentLevelId);

    }

    public void CheckIsAllLevelsFinish()
    {
        Debug.Log(UserData.CurrentLevelId + "--" + GameManager.LevelManager.Levels.Length);
        if (UserData.CurrentLevelId >= GameManager.LevelManager.Levels.Length - 1)
        {
            UserData.CurrentLevelId = 0;
        }
    }
}
