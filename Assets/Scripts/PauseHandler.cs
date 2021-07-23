 using UnityEngine;
 using System.Collections;

public class PauseHandler : MonoBehaviour
{
    public GameObject canvas;
    public GameObject cam;
    public GameObject player;

    GameObject currentCanvas;
    PlayerMovement pm;
    ProjectileController pj;

    bool Paused = false;

    void Start()
    {
        if (pm == null)
        {
            pm = player.GetComponent<PlayerMovement>();
        }
        if (pj == null)
        {
            pj = player.GetComponent<ProjectileController>();
        }
    }

    void Update()
    {
        if (pm == null)
        {
            pm = player.GetComponent<PlayerMovement>();
        }
        if (pj == null)
        {
            pj = player.GetComponent<ProjectileController>();
        }

        if (Input.GetKeyDown("escape"))
        {
            if (Paused == true)
            {
                Time.timeScale = 1.0f;
                Destroy(currentCanvas);
                cam.GetComponent<AudioSource>().UnPause();
                pm.Resume();
                pj.Resume();
                Paused = false;
            }
            else
            {
                Time.timeScale = 0.0f;
                currentCanvas = Instantiate(canvas, canvas.transform.position, Quaternion.identity);
                cam.GetComponent<AudioSource>().Pause();
                pm.Pause();
                pj.Pause();
                Paused = true;
            }
        }
    }
}