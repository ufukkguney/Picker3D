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
        UserData.CurrentLevelId++;
        UserData.MainLevelId++;
    }

    public void CheckIsAllLevelsFinish()
    {
        if (UserData.CurrentLevelId >= GameManager.LevelManager.Levels.Length - 1)
        {
            UserData.CurrentLevelId = 0;
        }
    }
}
