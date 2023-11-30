using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBullets : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 3f;
    public int maxBounces = 3;
    public int bounces = 0;
    public int duration = 10;

    public bool bouncyActive = false;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "player")
        {
            bouncyActive = true;
            Invoke(nameof(Deactivate), duration);
            Destroy(gameObject);
        }
    }

    void Deactivate()
    {
        bouncyActive = false;
    }
}
