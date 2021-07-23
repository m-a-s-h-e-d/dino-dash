using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryHandler : MonoBehaviour
{
    public AudioSource source;

    // Start is called before the first frame update
    void Awake()
    {
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
