using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullyAutomaticWeapon : MonoBehaviour
{
    public Bullet bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.2f;

    private float nextFireTime;

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 fireDirection = (mousePosition - (Vector2)firePoint.position).normalized;

        Bullet bulletInstance = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bulletInstance.Shoot(fireDirection);
    }
}
