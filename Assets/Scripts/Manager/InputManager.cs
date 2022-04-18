using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : CustomBehaviour
{
    private Vector2 _currentPos, _deltaPos, _lastPos;


    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        }
        else if (Input.GetMouseButton(0))
        {
            _currentPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            _deltaPos = _currentPos - _lastPos;
            //Debug.Log("delta pos : " + _deltaPos.x);

            GameManager.EventManager.Dragging(_deltaPos);
            _lastPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //_currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //_deltaPos = _currentPos - _lastPos;
        }
    }
}
