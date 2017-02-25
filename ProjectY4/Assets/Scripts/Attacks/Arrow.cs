﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    public EnemyHealth hp;
    public float speed;
    public PlayerAttack pa;
    public GameObject damageParticle;
    public GameObject damageNumber;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (pa.isAttacking == true)
        {
            GameObject objectColided = collision.gameObject;
            hp = collision.GetComponent<EnemyHealth>();
            if (collision.gameObject.tag == "Enemy" && hp.isDamaged == false)
            {
                objectColided.GetComponent<Rigidbody2D>().AddForce(pa.lastMovement() * 10000f);
                pa.hp = hp;
                pa.CmdDoDamage();

                Instantiate(damageParticle, objectColided.transform.position, objectColided.transform.rotation);
                //Creates a clone and sets the damage numbers to what the damage is
                var clone = (GameObject)Instantiate(damageNumber, objectColided.transform.position, Quaternion.Euler(Vector3.zero));
                clone.GetComponent<FloatingNumbers>().damageNum = pa.damage;

                Destroy(gameObject);

            }
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}