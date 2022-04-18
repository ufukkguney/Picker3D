using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CustomBehaviour
{
    private Rigidbody _rb;
    public bool CanMoveForward;

    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);
        GameManager.EventManager.OnDrag += Dragging;
        _rb = transform.GetComponent<Rigidbody>();
    }
    private void OnDestroy()
    {
        GameManager.EventManager.OnDrag -= Dragging;
    }

    private void Update()
    {
        if (CanMoveForward)
        {
            _rb.velocity = Vector3.forward * Time.deltaTime * 200;

        }

    }


    void Dragging(Vector3 deltaPos)
    {
        CanMoveForward = true;

        Debug.Log("dragging !!" + deltaPos.x);
        //_rb.AddForce(Vector3.forward * 50 * Time.deltaTime, ForceMode.VelocityChange);

        //_rb.velocity += Vector3.right * Time.deltaTime * deltaPos.x * 200000;

        //_rb.AddForce(Vector3.right * Time.deltaTime * deltaPos.x * 5000, ForceMode.VelocityChange);


        transform.position += new Vector3(deltaPos.x * Time.deltaTime * 75, 0, 0);

        var pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, -1.5f, 1.5f);
        transform.position = pos;
    }
}
