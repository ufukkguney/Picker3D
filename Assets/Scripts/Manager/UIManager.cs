﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class UIManager : CustomBehaviour
{
    public FinishPanel FinishPanel;
    public StartPanel StartPanel;
    private List<UIPanel> UIPanels;

    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);
        UIPanels = new List<UIPanel> { FinishPanel, StartPanel};

        UIPanels.ForEach(x =>
        {
            x.Initialize(this);
            //x.gameObject.SetActive(false);
        });
        StartPanel.ShowPanel();
    }
}