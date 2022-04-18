using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LevelCompleteCount : MonoBehaviour
{
    public int levelID;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start level ID : " + levelID);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update level ID : " + levelID);

    }
}
