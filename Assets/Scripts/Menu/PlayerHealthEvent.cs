using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PlayerHealthEvent : MonoBehaviour
{
    public static PlayerHealthEvent current;

    private void Awake()
    {
        current = this;
    }

    public Action<int> onPlayerHealthTrigger;

    public void PlayerHealthTrigger(int coins)
    {
        onPlayerHealthTrigger(coins);
    }
}
