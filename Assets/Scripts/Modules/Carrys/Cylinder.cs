using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : CarryableBase
{
    public override void OnTarget()
    {
        base.OnTarget();

        Debug.Log("cylinder");

    }
}
