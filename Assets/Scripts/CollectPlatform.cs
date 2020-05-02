using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectPlatform : MonoBehaviour
{
    int counter = 0;
    
    public int neededCoin;

    private GameObject canvas;
    public GameObject progressionBar;
    public Text coinAmountText;
    public GameObject failedScreen;

    public static AnimationFinish AnimationDone;
    public delegate void AnimationFinish();

    private void Awake()
    {
        //getting Canvas UI elements
        canvas = GameObject.FindGameObjectWithTag("Canvas");

        foreach (Transform child in canvas.transform)
        {
            if (child.gameObject.name.Contains("ProgressionBar"))
                progressionBar = child.gameObject;
            else if (child.gameObject.name.Contains("Coin"))
                coinAmountText = child.gameObject.GetComponent<Text>();
            else if (child.gameObject.name.Contains("Fail"))
                failedScreen = child.gameObject;
        }
        failedScreen.SetActive(false);
        //setting progression bar to white
        
    }
    private void OnEnable()
    {
        for (int i = 0; i < progressionBar.transform.childCount; i++)
        {
            progressionBar.transform.GetChild(i).GetComponent<Image>().color = Color.white;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //control how many coin do we get
        if (collision.transform.GetComponent<Coin>() != null)
        {
            counter++;
            Destroy(collision.transform.GetComponent<Coin>());
            coinAmountText.text = counter + "/" + neededCoin;
        }
    }

    public void AnimationEventForDestroyCoin()
    {
        //trigger from animation and for destroy coins
        Destroy(transform.parent.parent.Find("Coins").gameObject);
    }
    public void AnimationEventForKeepMoving()
    {
        //when animation done, control for keep moving or restart game
        if (counter >= neededCoin)
        {
            AnimationDone?.Invoke();

            for (int i = 0; i < progressionBar.transform.childCount; i++)
            {
                if (progressionBar.transform.GetChild(i).GetComponent<Image>().color == Color.white)
                {
                    progressionBar.transform.GetChild(i).GetComponent<Image>().color = Color.magenta;
                    break;
                }
                
            }
        }
        else
        {
            failedScreen.SetActive(true);
        }
    }


}
