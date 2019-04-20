using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : Character
{
    public GameObject character;

    [HideInInspector]
    public float horizontalMove = 0f;
    [HideInInspector]
    public float verticalMove = 0f;
    private Vector3 moveDir;


    public float attackRange;
    public Transform attackPosition;
    public LayerMask whatIsEnemies;

    private Rigidbody2D rbd2;
    private Animator anim;

    public float force;
    public float knockTime;

    private void Start()
    {
        rbd2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        Attack(damage);
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

    override public void Attack(int damage)
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, whatIsEnemies);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);

                Rigidbody2D enemy = enemiesToDamage[i].GetComponent<Rigidbody2D>();
                if (enemy != null)
                {
                    enemy.isKinematic = false;
                    Vector2 pushDir = enemy.transform.position - transform.position;
                    pushDir = pushDir.normalized * force;
                    enemy.AddForce(pushDir, ForceMode2D.Impulse);
                    StartCoroutine(KnockController(enemy));
                }
            }
        }
    }

    override public void TakeDamage(int damage)
    {
        playerHealth -= damage;

        if (playerHealth <= 0)
        {
            //Die
            Debug.Log("You Died");
        }
        Debug.Log("Damage Taken : " + damage + " Player Health : " + playerHealth);
    }

    private IEnumerator KnockController(Rigidbody2D enemy)
    {
        if (enemy != null )
        {
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
            enemy.isKinematic = true;
        }
    }
}