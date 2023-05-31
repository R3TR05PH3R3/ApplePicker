using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    static private Text _UI_TEXT;
    static private int COIN = 0;

    private Text txtCom;

    void Awake()
    {
        _UI_TEXT = GetComponent<Text>();
        if (PlayerPrefs.HasKey("Coin"))
        {
            COIN = PlayerPrefs.GetInt("Coin");
        }
        PlayerPrefs.SetInt("Coin", COIN);
    }

    static public int COIN_COUNT
    {
        get { return COIN; }
        private set
        {
            COIN = value;
            PlayerPrefs.SetInt("Coin", value);
            if (_UI_TEXT != null)
            {
                _UI_TEXT.text = "Total Coins: " + value.ToString("#,0");
            }
        }
    }

    static public void AddCoins(int amount)
    {
        COIN_COUNT += amount;
    }
    static public void DeduceCoins(int amount)
    {
        COIN_COUNT = COIN_COUNT - amount;
    }

    void Update()
    {
        // Update the UI text with the current coin count
        _UI_TEXT.text = "Total Coins: " + COIN_COUNT.ToString("#,0");
    }
}
