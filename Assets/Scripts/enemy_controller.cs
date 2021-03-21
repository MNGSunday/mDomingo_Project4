/*
Name: Marc Domingo
Student ID: 2346778
Chapman Email: mdomingo@chapman.edu
Course Number and Section: 236-03
Assignment: Project 4
This is my own work, and I did not cheat on this assignment.
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The following class simulates the concept of enemy behavior and contains functions that simulate how an enemy would behave in a game.

public class enemy_controller : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    private float timerBullet;
    private float maxTimerBullet;
    public GameObject bullet;

    public float timerMin = 20f;
    public float timerMax = 35f;
    public bool canFireBullets = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);

        timerBullet = 0;
        maxTimerBullet = Random.Range(timerMin, timerMax);
    }

    // Update is called once per frame
    void Update()
    {
        if (canFireBullets)
            StartCoroutine("FireBullet");

        if (Camera.main.WorldToViewportPoint(transform.position).y < 0)
            Destroy(this.gameObject);
    }

    void SpawnBullet()
    {
        Vector3 spawnPoint = transform.position;
        spawnPoint.y -= (bullet.GetComponent<Renderer>().bounds.size.y / 2) + (GetComponent<Renderer>().bounds.size.y / 2);
        GameObject.Instantiate(bullet, spawnPoint, transform.rotation);
    }

    IEnumerator FireBullet()
    {
        if (timerBullet >= maxTimerBullet)
        {
            // Spawn an enemy bullet
            SpawnBullet();
            timerBullet = 0;
            maxTimerBullet = Random.Range(timerMin, timerMax);
        }

        timerBullet += 0.1f;
        yield return new WaitForSeconds(0.1f);
    }
}
