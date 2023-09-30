using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchJoystickShooting : MonoBehaviour
{
    public Joystick joystick;
    public GameObject bulletPrefab;
    public Transform firePoint;

    public float bulletSpeed = 10f;

    void Update()
    {
        // Gets the input from the joystick
        Vector3 movement = new Vector3(joystick.Horizontal, joystick.Vertical, 0f).normalized;

        // Rotates the object to face the direction of movement
        if (movement != Vector3.zero)
        {
            float targetAngle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, targetAngle);
        }

        // Shoot when the Fire1 button is pressed (change to your specific input)
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instantiate a bullet prefab
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Get the rigidbody of the bullet and set its velocity to shoot in the direction the player is facing
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.up * bulletSpeed;

        // Destroy the bullet after a certain time (you can adjust the time according to your needs)
        Destroy(bullet, 2f);
    }
}
