using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageComplete : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource source;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            source.PlayOneShot(clip, 0.5f);
            StartCoroutine("CompleteAfterSeconds", 0.5f);
        }
    }

    private void CompleteStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator CompleteAfterSeconds(float delay)
    {
        yield return new WaitForSeconds(delay);
        CompleteStage();
    }
}
