﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : PlayerElement
{
    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("checkpoint"))
        {
            other.enabled = false;
            Player.Controller.CanGoForward(PlayerState.OnCheckPoint,true);
            Player.Controller.IsCheck(2);
        }
        else if (other.CompareTag("finish"))
        {
            other.enabled = false;
            Player.Controller.CanGoForward(PlayerState.OnFinish, true);
            GameManager.EventManager.ItsLevelDone();
        }
        else if (other.gameObject.name.Contains("Right"))
        {
            Player.Data.PlayerLocation = PlayerLocation.OnRight;
        }
        else if (other.gameObject.name.Contains("Left"))
        {
            Player.Data.PlayerLocation = PlayerLocation.OnLeft;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("Right") || other.gameObject.name.Contains("Left"))
        {
            Player.Data.PlayerLocation = PlayerLocation.OnMiddle;
        }
    }

}

