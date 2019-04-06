using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHealth;
    public float enemyMovementSpeed;
    public float startDazedTime;
    private float dazedTime;

    public Vector3 moveDirectionPush;
    public Rigidbody2D EnemyRigidBody;


    // Start is called before the first frame update
    void Start()
    {
        EnemyRigidBody = GetComponent<Rigidbody2D>();
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
        //Ini dummy cmn test gerak
        transform.position += Vector3.left *enemyMovementSpeed *Time.deltaTime;
    }

    public void TakeDamage(int damage)//, int force)
    {
        dazedTime = startDazedTime;
        enemyHealth -= damage;
        Debug.Log("Damage Taken : " + damage + " Enemy Health : "+ enemyHealth);
        //Knockback(force);
    }

    //Premature
    //public void Knockback(int force)
    //{
    //    EnemyRigidBody.AddForce(new Vector2(2, 0) * force);
    //}
}