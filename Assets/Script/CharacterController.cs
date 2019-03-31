using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public GameObject character;
    public AnimationController animationController;
    public float movementSpeed;

    public float horizontalMove = 0f;
    public float verticalMove = 0f;

    private Vector3 moveDir;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * movementSpeed;
        verticalMove = Input.GetAxisRaw("Vertical") * movementSpeed;
    }

    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        moveDir = new Vector2(horizontalMove, verticalMove).normalized;
        animationController.Walking();
        transform.position += moveDir * movementSpeed * Time.deltaTime;
    }

}