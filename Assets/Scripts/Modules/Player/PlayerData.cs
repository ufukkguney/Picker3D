using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    None,
    OnRoad,
    OnCheckPoint,
    OnFinish
}
public enum PlayerLocation
{
    OnMiddle,
    OnRight,
    OnLeft
}

public class PlayerData : PlayerElement
{
    public float SpeedTime;
    public PlayerState PlayerState;
    public PlayerLocation PlayerLocation;

    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);
    }
}
