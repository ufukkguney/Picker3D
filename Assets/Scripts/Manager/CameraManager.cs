using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : CustomBehaviour
{
    private Transform _target;
    public float SmoothSpeed;
    public Vector3 Offset;

    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);
        GameManager.EventManager.OnGameStart += GameStarted;
 
    }
    private void OnDestroy()
    {
        GameManager.EventManager.OnGameStart -= GameStarted;

    }

    private void GameStarted()
    {
        _target = GameManager.Player.transform;
    }

    private void FixedUpdate()
    {
        Vector3 desiredPosition = _target.position + Offset;
        Vector3 smoothedPosition = Vector3.Lerp(Camera.main.transform.position, desiredPosition, SmoothSpeed);
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, smoothedPosition.y, smoothedPosition.z);

        //Camera.main.transform.LookAt(_target);
    }

}
