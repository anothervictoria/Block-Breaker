using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] int health = 100;
    [SerializeField] int scoreValue = 43;

    [Header("Shooting")]
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.3f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject weapon;
    [SerializeField] float weaponSpeed = 10;

    [Header("Sound Effects")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfExplotion = 1f;
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.75f;
    [SerializeField] AudioClip shootClip;
    [SerializeField] [Range(0, 1)] float shootClipVolume = 0.25f;


    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if(shotCounter <= 0)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }      

    }

    private void Fire()
    {                          
        GameObject enemyWeapon = Instantiate(weapon, transform.position, Quaternion.identity) as GameObject;
        enemyWeapon.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -weaponSpeed);
        AudioSource.PlayClipAtPoint(shootClip, Camera.main.transform.position, shootClipVolume);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {        
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        FindObjectOfType<GameScore>().AddToScore(scoreValue);
        Destroy(gameObject);
        GameObject explotion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(explotion, durationOfExplotion);
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
    }
}
