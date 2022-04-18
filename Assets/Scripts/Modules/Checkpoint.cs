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
    private bool _isFail, _isDone;
    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);
        GameManager.EventManager.OnFail += ItsFail;
        UpdateText();
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
                collision.transform.GetComponent<CarryableBase>().OnTarget();
                _counter++;
                UpdateText();
                if (CheckpointNeededAmount <= _counter && !_isDone)
                {
                    _isDone = true;
                    SendThePlatform();
                }
            }
        }
    }

    private void SendThePlatform()
    {
        transform.DOMoveY(0, .5f).OnComplete(() => 
        {
            GameManager.EventManager.CheckpointSucces(); 
        }); ;
    }

    private void UpdateText()
    {
        _counterText.text = _counter.ToString() + " / " + CheckpointNeededAmount;
    }
}
