using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{
    public static Text CoinTextStatic;
    public  Text CoinText;

    public static int CurrentCoin;

    private void Start()
    {
        CurrentCoin = PlayerPrefs.GetInt("CurrentCoin");
        CoinTextStatic = CoinText;
    }

    private void Update()
    {
        PlayerPrefs.SetInt("CurrentCoin", CurrentCoin);
        
        CoinTextStatic.text = CurrentCoin.ToString();
    }
}
