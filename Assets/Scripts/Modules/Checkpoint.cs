using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class Checkpoint : CustomBehaviour
{
    public int CheckpointNeededAmount;
    [SerializeField]  private Transform _endpos;
    private int _counter;
    [SerializeField] private TextMeshPro _counterText;
    private bool _isFail;
    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);
        GameManager.EventManager.OnFail += ItsFail;
    }
    private void OnDestroy()
    {
        GameManager.EventManager.OnFail -= ItsFail;
    }

    private void ItsFail()
    {
        _isFail = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<CarryableBase>() != null && !_isFail)
        {
            if (!collision.transform.GetComponent<CarryableBase>().IsCollide)
            {
                _counter++;
                _counterText.text = _counter.ToString();
                collision.transform.GetComponent<CarryableBase>().OnTarget();
                if (CheckpointNeededAmount <= _counter)
                {
                    GameManager.EventManager.CheckpointSucces();
                    SendThePlatform();
                }
            }
        }
    }

    private void SendThePlatform()
    {
        transform.DOMoveY(0, .5f);
    }
}
