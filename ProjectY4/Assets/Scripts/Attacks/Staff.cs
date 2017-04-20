﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour {
    public GameObject fireAoe;
    List<GameObject> target;

    void Start () {
        target = new List<GameObject>();
    }

    public GameObject FireAoe(int damage)
    {

        GameObject clone = Instantiate(fireAoe, transform.position, transform.rotation);
        foreach (GameObject e in target)
        {
            e.GetComponent<EnemyHealth>().TakeDamage(damage);
        }

        return clone;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            target.Add(collision.gameObject);
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            target.Remove(collision.gameObject);
        }
    }

}
