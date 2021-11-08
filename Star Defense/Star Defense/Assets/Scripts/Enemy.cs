using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 200f;
    [SerializeField] int scoreValue = 10;
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShoots = 0.2f;
    [SerializeField] float maxTimeBetweenShoots = 3f;
    [SerializeField] float projectileSpeed = 15f;
    [SerializeField] GameObject laserEnemyPrefab;
    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration = 1f;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0, 1)] float deathSFXVolume = 0.7f;
    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.25f;
    Player playerRefference;
    int hitCounter;

    // Start is called before the first frame update
    void Start()
    {
        playerRefference = FindObjectOfType<Player>();
        shotCounter = Random.Range(minTimeBetweenShoots, maxTimeBetweenShoots);
        hitCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
            CountAndShoot();
    }

    private void CountAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShoots, maxTimeBetweenShoots);
        }
    }

    private void Fire()
    {
        GameObject laserSmall = Instantiate(laserEnemyPrefab, transform.position, Quaternion.identity) as GameObject;
        laserSmall.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
    }

    private void OnTriggerEnter2D(Collider2D projectile)
    {
        ProcessHit(projectile);
        EnemyDestruction();

    }

    private void EnemyDestruction()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            hitCounter++;
            GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
            Destroy(explosion, explosionDuration);
            AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSFXVolume);
            if (hitCounter == 1)
            {
                playerRefference.KillPoint();
                FindObjectOfType<GameSession>().AddScore(scoreValue);
            }
        }
    }

    private void ProcessHit(Collider2D projectile)
    {
        DamageDealer damageDealer = projectile.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
    }
}
