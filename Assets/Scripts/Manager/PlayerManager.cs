using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : CustomBehaviour
{
    public Player Player;

    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);

        Player.Initialize(gameManager);
    }

   
}
