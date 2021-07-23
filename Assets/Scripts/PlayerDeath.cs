using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource source;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("DeathFloor"))
        {
            if (gameObject != null)
            {
                source.PlayOneShot(clip, 0.5f);
            }
            Destroy(gameObject, 1f);
            LevelManager.instance.WaitRespawn();
        }
    }
}
