﻿public class UIPanel : CustomBehaviour
{
    public UIManager UIManager { get; set; }

    public virtual void Initialize(UIManager uiManager)
    {
        UIManager = uiManager;
        GameManager = UIManager.GameManager;
    }

    public virtual void ShowPanel()
    {
        gameObject.SetActive(true);
    }

    public virtual void HidePanel()
    {
    }
}