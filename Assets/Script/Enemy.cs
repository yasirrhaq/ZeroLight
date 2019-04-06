using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHealth;
    public float enemyMovementSpeed;
    public float startDazedTime;
    private float dazedTime;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dazedTime <= 0)
        {
            enemyMovementSpeed = 1.0f;
        }
        else
        {
            enemyMovementSpeed = 0;
            dazedTime -= Time.deltaTime;
        }

        if (enemyHealth <=0)
        {
            Destroy(gameObject);
        }
        transform.position += Vector3.left *enemyMovementSpeed *Time.deltaTime;
    }

    public void TakeDamage(int damage)
    {
        dazedTime = startDazedTime;
        enemyHealth -= damage;
        Debug.Log("Damage Taken : " + damage + " Enemy Health : "+ enemyHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Damage Given to Player");
        }
    }
}
