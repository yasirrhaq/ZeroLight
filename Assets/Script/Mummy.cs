using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mummy : Enemy
{
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }
   
    void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, enemyMovementSpeed * Time.deltaTime);
        }
    }

    override public void TakeDamage(int damage)
    {
        dazedTime = startDazedTime;
        enemyHealth -= damage;

        if (dazedTime <= 0)
        {
            enemyMovementSpeed = 1.0f;
        }
        else
        {
            enemyMovementSpeed = 0;
            dazedTime -= Time.deltaTime;
        }

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
        Debug.Log("Damage Taken : " + damage + " Enemy Health : " + enemyHealth);
    }
}
