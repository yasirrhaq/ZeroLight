using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public GameObject character;
    public AnimationController animationController;

    //Movement
    public float movementSpeed;
    [HideInInspector]
    public float horizontalMove = 0f;
    [HideInInspector]
    public float verticalMove = 0f;
    private Vector3 moveDir;

    //Attack
    //private float timeBtwAttack;
    //public float startTimeBtwAttack;
    public int damage;
    public float attackRange;
    public Transform attackPosition;
    public LayerMask whatIsEnemies;

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * movementSpeed;
        verticalMove = Input.GetAxisRaw("Vertical") * movementSpeed;
        PlayerAttack();
    }

    void FixedUpdate()
    {
        PlayerMovement();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition.position, attackRange);
    }

    void PlayerMovement()
    {
        moveDir = new Vector2(horizontalMove, verticalMove).normalized;
        //animationController.Walking();
        transform.position += moveDir * movementSpeed * Time.deltaTime;
    }

    void PlayerAttack()
    {

        //if (timeBtwAttack <= 0)
       // {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);//, 3);
                }
            }
       //     timeBtwAttack = startTimeBtwAttack;
       // }
       // else
       // {
      //      timeBtwAttack -= Time.deltaTime;
      //  }
    }

}