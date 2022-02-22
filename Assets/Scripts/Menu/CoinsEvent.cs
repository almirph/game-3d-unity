using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CoinsEvent : MonoBehaviour
{
    public static CoinsEvent current;

    private void Awake()
    {
        current = this;
    }

    public Action<float> onCoinsTrigger;
    public Func<float> onCoinsGetTrigger;

    public void CoinsTrigger(float coins)
    {
        onCoinsTrigger(coins);
    }

    public float GetCoinsTrigger()
    {
        return onCoinsGetTrigger();
    }

}
