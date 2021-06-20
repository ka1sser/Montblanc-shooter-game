using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [Header("Projectile Attributes")]
    [SerializeField] float speed;
    [SerializeField] int attackDamage;
    [SerializeField] GameObject destroyFX;

    Player playerScript;
    Vector2 targetPosition;

    private void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        targetPosition = playerScript.transform.position;
    }

    private void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (Vector2.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else
        {
            DestroyFX();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerScript.TakeDamage(attackDamage);
            DestroyFX();
        }
    }

    private void DestroyFX()
    {
        Instantiate(destroyFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
