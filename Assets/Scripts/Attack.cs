using UnityEngine;

public class Attack : MonoBehaviour
{
    public float projectileSpeed = 15f;
    public float projectileDamage = 10f;
    public Rigidbody2D rb;

    public AudioClip clip;
    public AudioSource source;

    private void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.right * projectileSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        source.PlayOneShot(clip, 0.5f);
        Destroy(gameObject);
    }
}
