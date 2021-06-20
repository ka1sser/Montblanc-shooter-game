using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    [Header("Boss Attributes")]
    [SerializeField] int health;
    [SerializeField] Enemy[] enemies;
    [SerializeField] float spawnOffset;
    [SerializeField] int damage;
    [SerializeField] GameObject deathFX;
    Slider healthBar;

    [Header("Attack Shotpoints")]
    [SerializeField] Transform[] shotPoints;

    [Header("Range Attack Configs")]
    [SerializeField] GameObject bossProjectile;
    [SerializeField] float shotTime;
    [SerializeField] float timeBetweenShots;

    [HideInInspector] public Transform player;
    private int halfHealth;
    private Animator anim;
    private SceneTransitions sceneTransitions;

    int timer = 5;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        healthBar = FindObjectOfType<Slider>();
        sceneTransitions = FindObjectOfType<SceneTransitions>();

        HealthConfig();
    }
    // Update is called once per frame
    void Update()
    {
        Invoke("Attack", timer);
    }

    private void HealthConfig()
    {
        halfHealth = health / 2;
        healthBar.maxValue = health;
        healthBar.value = health;
    }

    private void Attack()
    {
        if (player != null)
        {
            if (Time.time >= shotTime)
            {
                for (int i = 0; i < shotPoints.Length; i++)
                {
                    Instantiate(bossProjectile, shotPoints[i].transform.position, shotPoints[i].transform.rotation);
                }

                shotTime = Time.time + timeBetweenShots;
            }
        }
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        healthBar.value = health;
        if (health <= 0)
        {
            Instantiate(deathFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
            healthBar.gameObject.SetActive(false);
            sceneTransitions.LoadScene("Win");
        }

        if (health <= halfHealth)
        {
            anim.SetTrigger("stage2");
        }

        Enemy randomEnemy = enemies[Random.Range(0, enemies.Length)];
        Vector3 offsetPosition = new Vector3(spawnOffset, spawnOffset, 0);
        Instantiate(randomEnemy, transform.position + offsetPosition, transform.rotation);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Player>().TakeDamage(damage);
        }
    }
}