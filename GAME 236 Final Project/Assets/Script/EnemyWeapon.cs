using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public GameObject EnemyBulletPrefab;
    public Transform EnemyfirePoint;
    public float EnemyfireForce = 20f;

    public void EnemyFire()
    {
        GameObject bullet = Instantiate(EnemyBulletPrefab, EnemyfirePoint.position, EnemyfirePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(EnemyfirePoint.up * EnemyfireForce, ForceMode2D.Impulse);
    }
}
