using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class UIManager : CustomBehaviour
{
    public FinishPanel FinishPanel;
    public StartPanel StartPanel;
    public InGamePanel InGamePanel;
    private List<UIPanel> UIPanels;

    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);
        UIPanels = new List<UIPanel> { FinishPanel, StartPanel, InGamePanel};

        UIPanels.ForEach(x =>
        {
            x.Initialize(this);
        });
        StartPanel.ShowPanel();
    }
}