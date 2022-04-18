using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : CustomBehaviour
{
    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);

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
        Debug.Log("after level ID : " + UserData.CurrentLevelId);

    }
}
