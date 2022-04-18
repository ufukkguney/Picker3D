using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : CustomBehaviour
{
    public UIManager UIManager;
    public CameraManager CameraManager;
    public EventManager EventManager;
    public LevelManager LevelManager;
    public InputManager InputManager;
    public PlayerMain Player;
    public DataManager DataManager;
    public void Awake()
    {
        Application.targetFrameRate = 60;
        EventManager.Initialize(this);
        UIManager.Initialize(this);
        CameraManager.Initialize(this);
        LevelManager.Initialize(this);
        InputManager.Initialize(this);
        Player.Initialize(this);
        DataManager.Initialize(this);
    }

    private void Start()
    {
        EventManager.GameStart();
    }
}