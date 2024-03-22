using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public Transform target;
    public float speed = 3f;
    public float rotateSpeed = 0.0025f;
    private Rigidbody2D rb;
    public float hp = 5f;
    public EnemyWeapon EnemyWeapon;

    // Variables for firing rate control
    public float fireRate = 1.0f; // Adjust this value to control the firing rate
    private float nextFireTime = 0.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!target)
        {
            GetTarget();
        }
        else
        {
            RotateTowardsTarget();
        }

        // Check if it's time to fire
        if (Time.time >= nextFireTime)
        {
            Fire();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void GetTarget()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void RotateTowardsTarget()
    {
        Vector2 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
    }

    private void Fire()
    {
        EnemyWeapon.EnemyFire();
        // Set the next fire time based on the fire rate
        nextFireTime = Time.time + 1 / fireRate;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            target = null;
        }
        else if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            hp -= 1;
        }
    }
}
