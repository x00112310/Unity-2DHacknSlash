﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    private Equipment equipment; 
    private GameObject stats;
    private string data;
    public int currentLevel;
    public int currentXp;
    public int[] levels;
    // Use this for initialization
    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("Stats");
       

    }

    private void Update()
    {
        //Later only update if something changes but works for now
        UpdateStats();
        levelUp();
    }


    public void UpdateStats()
    {
        equipment = GameObject.Find("Inventory").GetComponent<Equipment>();
        int def = 0, str = 0, vit = 0;

        for (int i = 0; i < equipment.equipment.Count; i++)
        {
            def += equipment.equipment[i].Defence;
            str += equipment.equipment[i].Strength;
            vit += equipment.equipment[i].Vitality;
        }

        data = "  Strenght: " + str + "\n\n  Defence: " + def + "\n\n  Vitality: " + vit;
        stats.GetComponent<Text>().text = data;

    }

    public void levelUp()
    {
        if(currentXp >= levels[currentLevel])
        {
            currentLevel++;
        }
    }

    public void addXp(int xp)
    {
        currentXp += xp;
    }

}
