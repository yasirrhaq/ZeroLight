using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public string characterName;

    public int playerHealth;
    public int damage;

    public float movementSpeed;

    public abstract void TakeDamage(int damage);
    public abstract void Attack(int damage);
}
