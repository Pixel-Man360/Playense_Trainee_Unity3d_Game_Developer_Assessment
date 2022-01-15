using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectSound : MonoBehaviour
{

    private void OnEnable() 
    {
        Coins.OnCoinCollected += PlaySound;
    }

    private void OnDisable() 
    {
        Coins.OnCoinCollected -= PlaySound;
    }

    void PlaySound()
    {
        SoundManager.instance.PlaySound("Coin Collection");
    }
}
