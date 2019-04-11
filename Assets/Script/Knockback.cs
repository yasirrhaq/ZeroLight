﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float force;
    public float knockTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody2D enemy = collision.GetComponent<Rigidbody2D>();
            if (enemy != null)
            {
                enemy.isKinematic = false;
                Vector2 pushDir = enemy.transform.position - transform.position;
                pushDir = pushDir.normalized* force;
                enemy.AddForce(pushDir, ForceMode2D.Impulse);
                StartCoroutine(KnockController(enemy));
            }
        }
    }

    private IEnumerator KnockController(Rigidbody2D enemy)
    {
        if (enemy != null)
        {
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
            enemy.isKinematic = true;
        }
    }
}
