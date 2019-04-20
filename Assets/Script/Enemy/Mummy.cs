using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mummy : Enemy
{
    public Transform target;
    public float chaseRadius;
    public float attackRange;

    public Transform attackPosition;
    public LayerMask whatIsPlayer;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        enemyAttackCooldown -= Time.deltaTime;
        CheckDazed(); 
        CheckDistance();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition.position, attackRange);
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
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, enemyMovementSpeed * Time.deltaTime);
        }
        else
        {
            if (enemyAttackCooldown <=0)
            {
                Attack(damage);
            }
        }
    }

    public override void Attack(int damage)
    {
        Collider2D playerToDamage = Physics2D.OverlapCircle(attackPosition.position, attackRange, whatIsPlayer);
        if (playerToDamage != null)
        {
            playerToDamage.GetComponent<Character>().TakeDamage(damage);
            enemyAttackCooldown = 1f / enemyAttackSpeed;
        }
    }

    override public void TakeDamage(int damage)
    {
        dazedTime = startDazedTime;
        enemyHealth -= damage;

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
        Debug.Log("Damage Taken : " + damage + " Enemy Health : " + enemyHealth);
    }
}
