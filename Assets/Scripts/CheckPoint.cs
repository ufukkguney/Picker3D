using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<PlayerMovement>() != null)
        {
            transform.GetChild(0).GetComponent<Animator>().SetFloat("checkpoint", 1);
            collision.transform.GetComponent<Rigidbody>().drag = 1000;
        }
    }
}
