using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
}

public abstract class Enemy : MonoBehaviour
{
    public string enemyName;

    public int enemyHealth;
    public int damage;

    public float enemyMovementSpeed;
    public float enemyAttackSpeed;
    public float enemyAttackCooldown;

    public float startDazedTime;
    public float dazedTime;

    public abstract void TakeDamage(int damage);
    public abstract void Attack(int damage);
}