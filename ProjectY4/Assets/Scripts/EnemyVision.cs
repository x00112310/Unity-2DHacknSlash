﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour {
    private List<GameObject> list;
    private GameObject player;

    void Start () {
        list = new List<GameObject>();
    }
	
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && list != null)
        {
            list.Add(collision.gameObject);
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GetComponentInParent<EnemyScript>().enemyProjectile(collision.gameObject);
            player = collision.gameObject;
            foreach (GameObject p in list)
            {
                if (Vector3.Distance(p.transform.position, transform.position) < Vector3.Distance(player.transform.position, transform.position))
                {
                    player = p.gameObject;
                }
            }
            GetComponentInParent<EnemyScript>().transform.position = Vector2.MoveTowards(transform.position, player.transform.position, GetComponentInParent<EnemyScript>().speed * Time.deltaTime);
        }
     
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject == player)
        {
            list = new List<GameObject>();
        }
    }
}
