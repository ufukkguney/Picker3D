using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneric : LevelGenerator
{
    public int CurrentLevelId;
    public Checkpoint[] Checkpoints;

    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);

        //foreach (Checkpoint checkpoint in Checkpoints)
        //{
        //    checkpoint.Initialize(gameManager);
        //}
        for (int i = 0; i < Checkpoints.Length; i++)
        {
            Checkpoints[i].CheckpointNeededAmount = 5 * (i + 1) + (CurrentLevelId);
            Checkpoints[i].Initialize(gameManager);

        }
    }

    private void Start()
    {
        if (currentLevel)
            GenerateLevel(currentLevel);
    }
}
