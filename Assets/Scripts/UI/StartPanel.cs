using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanel : UIPanel
{
    public override void Initialize(UIManager uiManager)
    {
        base.Initialize(uiManager);
        GameManager.EventManager.OnDrag += LevelStarted;
    }
    private void OnDestroy()
    {
        GameManager.EventManager.OnDrag -= LevelStarted;

    }

    private void LevelStarted(Vector3 drag)
    {
        if (transform.gameObject.activeInHierarchy && drag.magnitude > 0)
        {
            transform.gameObject.SetActive(false);
        }
    }
}
