using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Main Attributes")]
    [SerializeField] int health = 3;
    [SerializeField] public int speed = 1;
    [SerializeField] public int damage = 1;
    [SerializeField] public float timeBetweenAttack = 1f;
    [SerializeField] GameObject deathFX;

    [Header("Pick-up Attributes")]
    [SerializeField] int pickupChance;
    [SerializeField] GameObject[] pickups;
    [SerializeField] int healthPickupChance;
    [SerializeField] GameObject[] healthPickups;

    [HideInInspector] public Transform player;
    private int offset = 10;

    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            int randomNumber = Random.Range(0, 101);
            if (randomNumber < pickupChance)
            {
                GameObject randomPickup = pickups[Random.Range(0, pickups.Length)];
                Instantiate(randomPickup, transform.position, transform.rotation);
            }

            int randomNumberHealth = Random.Range(0, 101);
            if (randomNumberHealth < healthPickupChance)
            {
                Vector3 offsetHealthPickup = new Vector3(offset, offset, 0);
                GameObject randomPickup = healthPickups[Random.Range(0, healthPickups.Length)];
                Instantiate(randomPickup, transform.position + offsetHealthPickup, transform.rotation);
            }

            Instantiate(deathFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

}
