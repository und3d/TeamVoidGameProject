using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunWeapon : MonoBehaviour
{
    public Bullet bulletPrefab;
    public Transform firePoint;
    public int pellets = 5;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        for (int i = 0; i < pellets; i++)
        {
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            Bullet bulletInstance = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            bulletInstance.Shoot(randomDirection);
        }
    }
}
