using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Text coins;
    [SerializeField] private GameObject seletBirds;
    [SerializeField] private GameObject selectLevel;
    [SerializeField] private List<Block> blockLevels;
    [SerializeField] private GameObject[] obj;


    public Image[] backGroundLevels;
    public Image[] birdsSelect;

    [SerializeField] private GraphicRaycaster ray;
    private PointerEventData eventData;
    private EventSystem eventSystem;

    private void Awake()
    {
        coins.text = SaveData.SaveLoader("Coins").ToString();
        for(int i = 0; i < blockLevels.Count; i++)
        {
            blockLevels[i].blockId = i;

        }
        if(SaveData.SaveLoaderBlock("Block").Length > 0)
        {
            for (int i = 0; i < blockLevels.Count; i++)
            {

                foreach(var n in SaveData.SaveLoaderBlock("Block"))
                {

                    if(i.ToString() == n.ToString())
                    {

                        blockLevels[i].gameObject.SetActive(false);
                    }
                }
            }
        }
        
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            CameraRect();
        }
    }

    public void PressStart()
    {
        foreach(var n in obj)
        {
            n.SetActive(false);
        }
        selectLevel.SetActive(true);
    }

    public void PressSelectBird()
    {
        foreach(var n in obj)
        {
            n.SetActive(false);
        }
        seletBirds.SetActive(true);
    }

    public void ExitPressStart()
    {
        foreach (var n in obj)
        {
            n.SetActive(true);
        }
        selectLevel.SetActive(false);
    }

    public void ExitPressSelectBird()
    {
        foreach (var n in obj)
        {
            n.SetActive(true);
        }
        seletBirds.SetActive(false);
    }

    public void PressExit()
    {
        Application.Quit();
    }

    private void CameraRect()
    {
        eventData = new PointerEventData(eventSystem);
        eventData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        ray.Raycast(eventData, results);
        if (results.Count > 0 && results[0].gameObject.layer == 6)
        {

            SaveData.Save("levelBackGround", results[0].gameObject.name);
            LevelLoader.LoadLevel(1);

        }
        else if(results.Count > 0 && results[0].gameObject.layer == 7)
        {

            SaveData.Save("bird", results[0].gameObject.name);
            seletBirds.SetActive(false);
            foreach(var n in obj)
            {
                n.SetActive(true);
            }
        }
        else if(results.Count > 0 && results[0].gameObject.layer == 8)
        {
            int temp = Convert.ToInt32(results[0].gameObject.GetComponentInChildren<Text>().text);
            if(SaveData.SaveLoader("Coins") >= temp)
            {
                temp = SaveData.SaveLoader("Coins") - temp;
                SaveData.SaveBlock("Block", results[0].gameObject.GetComponent<Block>().blockId.ToString());
                SaveData.Save("Coins", temp.ToString());
                coins.text = temp.ToString();
                results[0].gameObject.SetActive(false);
                return;
            }
            
        }
    }
}
