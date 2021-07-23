using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float fireRate = 1f;
    public Transform firingPoint;
    public GameObject projectilePrefab;
    public bool isPaused = false;

    public AudioClip clip;
    public AudioSource source;

    float timeUntilFire;
    PlayerMovement pm;

    private void Start()
    {
        pm = gameObject.GetComponent<PlayerMovement>();
        isPaused = false;
    }

    private void Update()
    {
        Debug.Log(isPaused);
        Collider2D faceCheck = Physics2D.OverlapCircle(pm.face.position, 0.5f, pm.groundLayers);
        if (Input.GetMouseButtonDown(0) && timeUntilFire < Time.time && faceCheck == null && !isPaused)
        {
            source.PlayOneShot(clip, 0.4f);
            Shoot();
            timeUntilFire = Time.time + fireRate;
        }
    }

    private void Shoot()
    {
        float angle = pm.isFacingRight ? 0f : 180f;
        Instantiate(projectilePrefab, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
    }

    public void Pause()
    {
        isPaused = true;
    }

    public void Resume()
    {
        isPaused = false;
    }
}
