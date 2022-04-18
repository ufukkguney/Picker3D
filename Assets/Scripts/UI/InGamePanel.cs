using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InGamePanel : UIPanel
{
    [SerializeField] private Text _levelText;
    public override void Initialize(UIManager uiManager)
    {
        base.Initialize(uiManager);
        GameManager.EventManager.OnStartNewLevel += UpdateText;
        GameManager.EventManager.OnGameStart += UpdateText;
        GameManager.EventManager.OnFail += UpdateTextErase;
        GameManager.EventManager.OnLevelFinish += UpdateTextErase;
        GameManager.EventManager.OnDrag += LevelStarted;

    }
    private void OnDestroy()
    {
        GameManager.EventManager.OnStartNewLevel -= UpdateText;
        GameManager.EventManager.OnGameStart -= UpdateText;
        GameManager.EventManager.OnFail -= UpdateTextErase;
        GameManager.EventManager.OnLevelFinish -= UpdateTextErase;
        GameManager.EventManager.OnDrag -= LevelStarted;

    }

    private void UpdateText()
    {
        _levelText.text = "Level " + (UserData.CurrentLevelId + 1);
    }

    private void UpdateTextErase()
    {
        _levelText.text = " ";
    }
    private void LevelStarted(Vector3 drag)
    {
        if (!_levelText.gameObject.activeInHierarchy && drag.magnitude > 0)
        {
            _levelText.gameObject.SetActive(true);
        }
    }
}
