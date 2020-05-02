using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    public GameObject level1, level2;
    private void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(() =>
        {
            level1.SetActive(false);
            level2.SetActive(true);
            transform.gameObject.SetActive(false);

        });
    }
}
