﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class EnemyHealth : NetworkBehaviour
{
    public const int maxHealth = 100;
    [SyncVar(hook = "OnChangeHealth")] public int currentHealth = maxHealth;
    public RectTransform healthbar;
    public bool destroyOnDeath;
    public bool isDamaged;
    public float invincibility;
    private float invicibilityCounter;
    private Stats playerStats;
    public int expToGive;

    private void Start()
    {
        playerStats = FindObjectOfType<Stats>();
    }

    public void FixedUpdate()
    {
        invincibilityCounter();
    }

    [Command]
    public void CmdTakeDamage(int amount)
    {
        RpcTakeDamage(amount);
    }

    [ClientRpc]
    public void RpcTakeDamage(int amount)
    {

        if (isDamaged == false)
        {
         
            isDamaged = true;
            invicibilityCounter = invincibility;

            currentHealth -= amount;

            if (currentHealth <= 0)
            {
                playerStats.addXp(expToGive);
                if (destroyOnDeath)
                {
                    Destroy(gameObject);
                }

            }
        }
    }

    //Sync healthbar to damage by server
    void OnChangeHealth(int health)
    {
        healthbar.sizeDelta = new Vector2(health, healthbar.sizeDelta.y);
    }

    private void invincibilityCounter()
    {
        if (invicibilityCounter > 0)
        {
            invicibilityCounter -= Time.fixedDeltaTime;
        }
        if (invicibilityCounter <= 0)
        {
            isDamaged = false;
    
        }
    }


}
