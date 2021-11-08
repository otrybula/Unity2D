using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //config params
    [Header("Player")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 0.5f;
    [SerializeField] int health = 100;
    int maxHealth;

    [Header("Projectile")]
    [SerializeField] GameObject laserSmallPrefab;
    [SerializeField] GameObject laserBigPrefab;
    [SerializeField] float projectileSpeed = 15f;
    [SerializeField] float projectileDelay = 0.25f;
    Coroutine firingCoroutine;
    [SerializeField] int killsToUpgrade = 10;
    [SerializeField] int healthPerCombo = 10;
    [SerializeField] int upgradeLevel = 0;
    [SerializeField] int pointsGathered = 0;
    [SerializeField] int decreaseUpgradeLevelBy = 1;

   [Header("Effects")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration = 1f;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.25f;
    [SerializeField] [Range(0, 1)] float deathSFXVolume = 0.7f;

    
    float xMin;
    float xMax;
    float yMin;
    float yMax;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        SetUpBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {

            if (upgradeLevel == 0)
            {
                GameObject laserSmall = Instantiate(laserSmallPrefab, transform.position, Quaternion.identity) as GameObject;
                laserSmall.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
               AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
            }

            if (upgradeLevel == 1)
            {
                Vector3 projectileOne = new Vector3(transform.position.x - 0.25f, transform.position.y, transform.position.z);
                Vector3 projectileTwo = new Vector3(transform.position.x + 0.25f, transform.position.y, transform.position.z);
                GameObject laserSmall1 = Instantiate(laserSmallPrefab, projectileOne, Quaternion.identity) as GameObject;
                GameObject laserSmall2 = Instantiate(laserSmallPrefab, projectileTwo, Quaternion.identity) as GameObject;
                laserSmall1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
                laserSmall2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
                AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
            }

            if (upgradeLevel == 2)
            {
                Vector3 projectileOne = new Vector3(transform.position.x - 0.625f, transform.position.y, transform.position.z);
                Vector3 projectileTwo = new Vector3(transform.position.x + 0.625f, transform.position.y, transform.position.z);
                GameObject laserSmall1 = Instantiate(laserSmallPrefab, projectileOne, Quaternion.identity) as GameObject;
                GameObject laserSmall2 = Instantiate(laserSmallPrefab, projectileTwo, Quaternion.identity) as GameObject;
                GameObject laserSmall = Instantiate(laserSmallPrefab, transform.position, Quaternion.identity) as GameObject;
                laserSmall1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
                laserSmall2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
                laserSmall.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
                AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
            }

            if (upgradeLevel == 3)
            {
                Vector3 projectileOne = new Vector3(transform.position.x - 0.625f, transform.position.y, transform.position.z);
                Vector3 projectileTwo = new Vector3(transform.position.x + 0.625f, transform.position.y, transform.position.z);
                GameObject laserSmall1 = Instantiate(laserSmallPrefab, projectileOne, Quaternion.identity) as GameObject;
                GameObject laserSmall2 = Instantiate(laserSmallPrefab, projectileTwo, Quaternion.identity) as GameObject;
                GameObject laserBig = Instantiate(laserBigPrefab, transform.position, Quaternion.identity) as GameObject;
                laserSmall1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
                laserSmall2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
                laserBig.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
                AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
            }

            if (upgradeLevel == 4)
            {
                Vector3 projectileOne = new Vector3(transform.position.x - 0.625f, transform.position.y, transform.position.z);
                Vector3 projectileTwo = new Vector3(transform.position.x + 0.625f, transform.position.y, transform.position.z);
                GameObject laserBig1 = Instantiate(laserBigPrefab, projectileOne, Quaternion.identity) as GameObject;
                GameObject laserBig2 = Instantiate(laserBigPrefab, projectileTwo, Quaternion.identity) as GameObject;
                GameObject laserSmall = Instantiate(laserSmallPrefab, transform.position, Quaternion.identity) as GameObject;
                laserBig1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
                laserBig2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
                laserSmall.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
                AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
            }

            if (upgradeLevel == 5)
            {
                Vector3 projectileOne = new Vector3(transform.position.x - 0.625f, transform.position.y, transform.position.z);
                Vector3 projectileTwo = new Vector3(transform.position.x + 0.625f, transform.position.y, transform.position.z);
                GameObject laserBig1 = Instantiate(laserBigPrefab, projectileOne, Quaternion.identity) as GameObject;
                GameObject laserBig2 = Instantiate(laserBigPrefab, projectileTwo, Quaternion.identity) as GameObject;
                GameObject laserBig = Instantiate(laserBigPrefab, transform.position, Quaternion.identity) as GameObject;
                laserBig1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
                laserBig2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
                laserBig.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
                AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
            }

            yield return new WaitForSeconds(projectileDelay);

        }
    }


    private void OnTriggerEnter2D(Collider2D projectile)
    {
        ProcessHit(projectile);
        GameOver();

    }

    private void GameOver()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            DeathFX();
            FindObjectOfType<Level>().LoadGameOver();
        }
    }

    private void DeathFX()
    {
        GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(explosion, explosionDuration);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSFXVolume);
    }
    private void ProcessHit(Collider2D projectile)
    {
        DamageDealer damageDealer = projectile.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        ResetKillPoints();
        DecreaseUpgradeLevel();
    }
    private void SetUpBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;

    }
    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }

        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }
    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime *moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXPos,newYPos);
    }
    public void KillPoint()
        {
        pointsGathered++;

        if (upgradeLevel < 5)
        {
            if (pointsGathered == killsToUpgrade)
            {
                ResetKillPoints();
                upgradeLevel++;
            }
        }
        if (upgradeLevel == 5)
        {
            if (pointsGathered == killsToUpgrade)
            {
                ResetKillPoints();
                if (health < maxHealth)
                { 
               health = health+healthPerCombo;
                }
                if (health > maxHealth)
                {
                    health = maxHealth;
                }
            }
        }
        }
    public void ResetKillPoints()
        {
        pointsGathered = 0;
        }
    public void ResetUpgradeLevel()
    {
        pointsGathered = 0;
    }
    public void DecreaseUpgradeLevel()
    {
        if (upgradeLevel > 0)
        { 
        upgradeLevel = upgradeLevel - decreaseUpgradeLevelBy;
        }
    }
    public int GetUpgradeLevel()
    {
        return upgradeLevel;
    }
    public int GetHealth()
    {
        return health;
    }
    public int GetMaxHealth()
    {
        return maxHealth;
    }

}
