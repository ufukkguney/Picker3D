using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : CustomBehaviour
{
    public Action OnGameStart;
    public Action<Vector3> OnDrag;
    public Action OnCheckpoint;
    public Action OnCheckpointDone;
    public Action OnFail;
    public Action OnLevelFinish;
    public Action OnStartNewLevel;

    #region Initialize

    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);
    }

    private void OnDestroy()
    {
    }

    #endregion

    public void GameStart()
    {
        OnGameStart?.Invoke();
    }

    public void Dragging(Vector3 dragVector)
    {
        OnDrag?.Invoke(dragVector);
    }
    public void CheckpointSucces()
    {
        OnCheckpointDone?.Invoke();
    }

    public void ItsFail()
    {
        OnFail?.Invoke();
    }

    public void ItsLevelDone()
    {
        OnLevelFinish?.Invoke();
    }
    public void NewLevelStart()
    {
        OnStartNewLevel?.Invoke();
    }
}