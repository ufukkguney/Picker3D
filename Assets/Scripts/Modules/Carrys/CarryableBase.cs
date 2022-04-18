using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CarryableBase : CustomBehaviour
{
    [SerializeField] private BoxCollider _boxCollider;
    public bool IsCollide;

    public virtual void OnTarget()
    {
        IsCollide = true;

        transform.DOScale(transform.localScale.x + .25f, .25f).OnComplete(() => 
        {
            transform.DOScale(0, .5f).OnComplete(()=> { Destroy(gameObject); });
        });

    }

}
