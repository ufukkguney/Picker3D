using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : CustomBehaviour
{
    private Vector2 _currentPos, _deltaPos, _lastPos;


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

            GameManager.EventManager.Dragging(_deltaPos);
            _lastPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }
    }
}
