using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public static Coin coin;

    public Text coins;

    private void Awake()
    {
        coin = this;
        coins.text = SaveData.SaveLoader("coins").ToString();
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            int temp = Convert.ToInt32(coins.text);
            temp += 1;
            coins.text = temp.ToString();
            transform.position = new Vector2(transform.position.x + 11.7f + 1.1f, UnityEngine.Random.RandomRange(LevelControler.singeltone.minValue + 0.2f, LevelControler.singeltone.maxValue - 0.3f));
        }
    }

    public void SaveCoins()
    {
        SaveData.Save("coins", coins.text);
    }

}
