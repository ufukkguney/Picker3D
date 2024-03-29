﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerElement
{
    public Rigidbody Rigidbody;
    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);

        GameManager.EventManager.OnDrag += Dragging;
        GameManager.EventManager.OnCheckpointDone += CheckpointDone;
        GameManager.EventManager.OnStartNewLevel += NewLevelStart;
        GameManager.EventManager.OnGameStart += SetPosition;

    }
    private void OnDestroy()
    {
        GameManager.EventManager.OnDrag -= Dragging;
        GameManager.EventManager.OnCheckpointDone -= CheckpointDone;
        GameManager.EventManager.OnStartNewLevel -= NewLevelStart;
        GameManager.EventManager.OnGameStart -= SetPosition;


    }
    private void FixedUpdate()
    {
        if (Player.Data.PlayerState == PlayerState.OnRoad)
        {
            Rigidbody.velocity = Vector3.forward * Time.deltaTime * Player.Data.SpeedTime;
        }
    }

    void Dragging(Vector3 deltaPos)
    {
        if (deltaPos.magnitude > 0 && Player.Data.PlayerState != PlayerState.OnFinish)
        {
            Player.Data.PlayerState = PlayerState.OnRoad;
            if (Player.Data.PlayerLocation == PlayerLocation.OnMiddle)
            {
                Rigidbody.AddForce(Vector3.right * Time.deltaTime * deltaPos.x * 7500, ForceMode.VelocityChange);
            }
            else if (Player.Data.PlayerLocation == PlayerLocation.OnRight)
            {
                float tempX = Vector3.right.x * Time.deltaTime * deltaPos.x * 7500;

                if (tempX < 0)
                {
                    Rigidbody.AddForce(new Vector3(tempX, 0, 0), ForceMode.VelocityChange);
                }
            }
            else if (Player.Data.PlayerLocation == PlayerLocation.OnLeft)
            {
                float tempX = Vector3.right.x * Time.deltaTime * deltaPos.x * 7500;

                if (tempX > 0)
                {
                    Rigidbody.AddForce(new Vector3(tempX, 0, 0), ForceMode.VelocityChange);
                }
            }
        }

    }
    private void SetPosition()
    {
        Player.transform.position += Vector3.forward * 45 * (UserData.MainLevelId);
    }

    public void CanGoForward(PlayerState playerState, bool isKinematic)
    {
        Player.Data.PlayerState = playerState;
        Rigidbody.isKinematic = isKinematic;
    }

    private void CheckpointDone()
    {
        CanGoForward(PlayerState.OnRoad, false);
    }
    private void NewLevelStart()
    {
        CanGoForward(PlayerState.OnRoad, false);
    }

    public void IsCheck(float time)
    {
        StartCoroutine(IsCheckpointDone(time));
    }

    private IEnumerator IsCheckpointDone(float time)
    {
        yield return new WaitForSeconds(time);
        if (Rigidbody.isKinematic)
        {
            GameManager.EventManager.ItsFail();
        }
    }
}
