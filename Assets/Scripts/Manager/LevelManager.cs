using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : CustomBehaviour
{
    #region Initialize
    public Level[] Levels;
    [SerializeField] private LevelGeneric _levelGeneric;

    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);
        GameManager.EventManager.OnGameStart += GameStart;
        GameManager.EventManager.OnStartNewLevel += LevelDone;
    }

    private void OnDestroy()
    {
        GameManager.EventManager.OnGameStart -= GameStart;
        GameManager.EventManager.OnStartNewLevel -= LevelDone;

    }

    #endregion


    public void GameStart()
    {
        BringTheLevel(Levels[UserData.CurrentLevelId], Vector3.forward * 45 * UserData.MainLevelId, UserData.CurrentLevelId);

        BringTheLevel(Levels[UserData.CurrentLevelId + 1], Vector3.forward * 45 * (UserData.MainLevelId + 1), UserData.CurrentLevelId + 1);

    }
    private void LevelDone()
    {
        GameManager.DataManager.CheckIsAllLevelsFinish();
        BringTheLevel(Levels[UserData.CurrentLevelId + 1], Vector3.forward * 45 * (UserData.MainLevelId + 1), UserData.CurrentLevelId + 1);
    }

    private void BringTheLevel(Level levelData, Vector3 position, int levelID)
    {
        LevelGeneric currentLevel = Instantiate(_levelGeneric, position, Quaternion.identity);
        currentLevel.currentLevel = levelData;
        currentLevel.CurrentLevelId = levelID;
        currentLevel.Initialize(GameManager);
    }


}

