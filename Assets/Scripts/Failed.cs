using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Failed : MonoBehaviour
{
    private void Start()
    {
        this.transform.GetComponent<Button>().onClick.AddListener(() =>
        {
            SceneManager.LoadScene("MainScene");
        });
    }
}
