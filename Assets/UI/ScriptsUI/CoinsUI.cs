using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsUI : MonoBehaviour
{
    [SerializeField]
    private List<Image> coins;

    [SerializeField]
    private Color grey;

    public void ChangeCoinSaturation()
    {
        foreach (var coin in coins)
        {
            if (coin.color != grey)
            {
                coin.color = grey;
            }
        }
    }
}
