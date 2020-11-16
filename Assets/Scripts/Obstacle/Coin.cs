using System;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CoinController.CurrentCoin += 1;
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Magnet"))
        {
            CoinController.CurrentCoin += 1;
            Destroy(gameObject);
        }
    }
}

