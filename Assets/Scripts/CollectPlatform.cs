using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectPlatform : MonoBehaviour
{
    int counter = 0;
    public int neededCoin;

    public GameObject progressionBar;
    public Text coinAmountText;

    public static AnimationFinish AnimationDone;
    public delegate void AnimationFinish();

    private void Start()
    {
        for (int i = 0; i < progressionBar.transform.childCount; i++)
        {
            progressionBar.transform.GetChild(0).GetComponent<Image>().color = Color.white;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<Coin>() != null)
        {
            counter++;
            Destroy(collision.transform.GetComponent<Coin>());
            coinAmountText.text = counter + "/" + neededCoin;
        }
    }

    public void AnimationEventForDestroyCoin()
    {
        Destroy(transform.parent.parent.Find("Coins").gameObject);
    }
    public void AnimationEventForKeepMoving()
    {
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
    }


}
