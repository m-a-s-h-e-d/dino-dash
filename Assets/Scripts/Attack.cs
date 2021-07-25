using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float projectileSpeed = 15f;
    public float projectileDamage = 10f;
    public Rigidbody2D rb;

    private void Start()
    {
        // Nothing
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.right * projectileSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
