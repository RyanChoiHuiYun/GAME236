using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float hp = 1f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("EnemyBullet") || collision.collider.tag.Equals("Enemy"))
        {
            return;
        }

        if (collision.collider.tag.Equals("PlayerBullet") || collision.collider.tag.Equals("Wall"))
        {
            hp -= 1;
        }
        if (collision.collider.tag.Equals("Player"))
        {
            Destroy(collision.gameObject);
        }


        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
