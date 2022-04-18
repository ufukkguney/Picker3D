using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class FinishPanel : UIPanel
{
    public GameObject FailPanel, CompletedPanel;
    public override void Initialize(UIManager uiManager)
    {
        base.Initialize(uiManager);

        GameManager.EventManager.OnFail += OpenThePanel;
        GameManager.EventManager.OnLevelFinish += OpenTheSuccesPanel;
    }
    private void OnDestroy()
    {
        GameManager.EventManager.OnFail -= OpenThePanel;
        GameManager.EventManager.OnLevelFinish -= OpenTheSuccesPanel;

    }
    private void OpenThePanel()
    {
        Debug.Log("ui panel from open the panel");
        FailPanel.gameObject.SetActive(true);
    }
    private void OpenTheSuccesPanel()
    {
        Debug.Log("ui panel from open the panel");
        CompletedPanel.gameObject.SetActive(true);
    }

    public void Restart()
    {
        DOTween.KillAll();
        SceneManager.LoadScene(0);
    }
    public void LevelCompletedOnClick()
    {
        CompletedPanel.SetActive(false);
        GameManager.EventManager.NewLevelStart();
    }
}
