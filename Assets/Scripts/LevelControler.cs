using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelControler : MonoBehaviour
{
    public static LevelControler singeltone;

    [SerializeField] private Sprite[] backrounds;
    [SerializeField] private GameObject[] birds;
    [SerializeField] private Image pausePanel;
    public Text score;
    private int backGroundId;
    [NonSerialized] public int birdsId;
    [NonSerialized] public bool isDead;
    private bool isPause;

    [Header("Налаштування персонажу")]
    public float jumpPower;
    public float speed;

    [Header("Генерація перешкод")]
    public float minValue;
    public float maxValue;


    [Header("Налаштування вікна програшу та паузи")]
    [SerializeField] Text CoinsText;
    [SerializeField] Text ScoreText;
    [SerializeField] Text textPanel;



    void Awake()
    {
        singeltone = this;
        InitLevel();
    }

    void Start()
    {
        InitObjects();
    }

    void Update()
    {
        if(Player.player.isDead)
        {
            pausePanel.gameObject.SetActive(true);
            CoinsText.text = Coin.coin.coins.text;
            ScoreText.text = score.text;
            textPanel.text = "You louse!";
            Coin.coin.SaveCoins();
        }
    }

    private void InitLevel()
    {
        backGroundId = SaveData.SaveLoader("levelBackGround");
        birdsId = SaveData.SaveLoader("bird");
        StartCoroutine("ScoreCounter");
        isPause = false;
        Time.timeScale = 1;
    }

    private void InitObjects()
    {
        foreach(var backGroundSprite in GetComponentsInChildren<SpriteRenderer>())
        {
            backGroundSprite.sprite = backrounds[backGroundId];
        }
        birds[birdsId].SetActive(true);
    }

    IEnumerator ScoreCounter()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            int temp = Convert.ToInt32(score.text);
            temp += 1;
            score.text = temp.ToString();
            speed = 1 + (temp / 15) * Time.deltaTime;
        }
        
    }

    public void Pause()
    {
        if(isPause == false && Player.player.isDead == false)
        {
            Time.timeScale = 0;
            Coin.coin.SaveCoins();
            pausePanel.gameObject.SetActive(true);
            isPause = true;
            CoinsText.text = Coin.coin.coins.text;
            ScoreText.text = score.text;
            StopAllCoroutines();
        }
        else if(isPause == true && Player.player.isDead == false)
        {
            Time.timeScale = 1;
            pausePanel.gameObject.SetActive(false);
            isPause = false;
            StartCoroutine("ScoreCounter");
        }
    }

    public void Exit()
    {
        LevelLoader.LoadLevel(0);
    }

    public void Reload()
    {
        LevelLoader.LoadLevel(1);
        Time.timeScale = 1;
    }


}
