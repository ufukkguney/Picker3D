using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [RangeAttribute(0, 15)]
    public float speed;
    private GameObject nextLevelScreen;

    private Rigidbody rb;

    private Vector3 offset, screenSpace,curScreenSpace, curPosition,curPosTemp,curPosDelta;
    private GameObject canvas;

    private void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        foreach (Transform child in canvas.transform)
        {
            if (child.gameObject.name.Contains("NextLevel"))
                nextLevelScreen = child.gameObject;
        }

        rb = GetComponent<Rigidbody>();
        CollectPlatform.AnimationDone = null;
        CollectPlatform.AnimationDone += AnimationDoneKeepMove;
        
    }
    void Update()
    {
        //moving player forward
        rb.AddForce(Vector3.forward * speed);

        //drag player
        if (Input.GetMouseButtonDown(0))
        {
            screenSpace = Camera.main.WorldToScreenPoint(transform.position);
            offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, screenSpace.y, screenSpace.z));
        }
        if (Input.GetMouseButton(0))
        {
            curScreenSpace = new Vector3(Input.mousePosition.x, screenSpace.y, screenSpace.z);
            curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
            if (curPosTemp.y == 0)
                curPosTemp = curPosition;

            curPosDelta = curPosition - curPosTemp;
                transform.position += new Vector3(curPosDelta.x, 0, 0) * Time.deltaTime * 65f;
            curPosTemp = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;
        }
    }

    //if checkpoint send a event keep move
    public void AnimationDoneKeepMove()
    {
            rb.drag = 0;
    }

    // when level finish trigger
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<Finish>() != null)
        {
            rb.drag = 1000;
            nextLevelScreen.gameObject.SetActive(true);
        }
    }
}
