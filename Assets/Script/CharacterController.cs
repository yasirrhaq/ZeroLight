using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public GameObject character;
    public AnimationController animationController;

    
    public float movementSpeed;
    [HideInInspector]
    public float horizontalMove = 0f;
    [HideInInspector]
    public float verticalMove = 0f;
    private Vector3 moveDir;


    public int damage;
    public float attackRange;
    public Transform attackPosition;
    public LayerMask whatIsEnemies;

    private Rigidbody2D rbd2;
    private Animator anim;

    private void Start()
    {
        rbd2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
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
        rbd2.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * movementSpeed;

        anim.SetFloat("MoveX", rbd2.velocity.x);
        anim.SetFloat("MoveY", rbd2.velocity.y);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            anim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }
    }

    void PlayerAttack()
    {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
            }
    }
}