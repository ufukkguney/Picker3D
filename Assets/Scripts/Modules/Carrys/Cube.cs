using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : CarryableBase
{
    public override void OnTarget()
    {
        base.OnTarget();
        Debug.Log("cube");

    }
}
