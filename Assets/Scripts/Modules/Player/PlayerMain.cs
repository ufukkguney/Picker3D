﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : CustomBehaviour
{
    public PlayerData Data;
    public PlayerView View;
    public PlayerController Controller;

    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);

        Data.Player = this;
        View.Player = this;
        Controller.Player = this;

        Data.Initialize(gameManager);
        View.Initialize(gameManager);
        Controller.Initialize(gameManager);
    }

    
}

