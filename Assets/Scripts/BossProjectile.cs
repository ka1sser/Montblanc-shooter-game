using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    [Header("Projectile Config")]
    [SerializeField] int speed;
    [SerializeField] int attackDamage;

    int random;
    int lifeTime = 5;
    Player playerScript;

    private void Start()
    {
        random = Random.Range(0, 7);
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Invoke("DestroyProjectile", lifeTime);
    }

    void Update()
    {
        RandomFire();
    }

    private void RandomFire()
    {
        if (random == 0)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        if (random == 1)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        if (random == 2)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if (random == 3)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        if (random == 4)
        {
            Vector2 upleft = new Vector2(-1, 1);
            transform.Translate(upleft * speed * Time.deltaTime);
        }
        if (random == 5)
        {
            Vector2 upright = new Vector2(1, 1);
            transform.Translate(upright * speed * Time.deltaTime);
        }
        if (random == 6)
        {
            Vector2 downleft = new Vector2(-1, -1);
            transform.Translate(downleft * speed * Time.deltaTime);
        }
        if (random == 7)
        {
            Vector2 downright = new Vector2(1, -1);
            transform.Translate(downright * speed * Time.deltaTime);
        }
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerScript != null)
        {
            if (collision.tag == "Player")
            {
                playerScript.TakeDamage(attackDamage);
                Destroy(gameObject);
            }
        }
    }
}
