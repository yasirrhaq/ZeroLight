using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mummy : Enemy
{
    public Transform target;
    public float chaseRadius;
    public float attackRadius;

    public float force;
    public float knockTime;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDazed();
        CheckDistance();
    }
    
    void CheckDazed()
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

        Rigidbody2D enemy = this.GetComponent<Rigidbody2D>();
        if (enemy != null)
        {
            enemy.isKinematic = false;
            Vector2 pushDir = enemy.transform.position - transform.position;
            pushDir = pushDir.normalized * force;
            enemy.AddForce(pushDir, ForceMode2D.Impulse);
            StartCoroutine(KnockController(enemy));
        }

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
        Debug.Log("Damage Taken : " + damage + " Enemy Health : " + enemyHealth);
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
