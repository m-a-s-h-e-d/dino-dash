using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public Transform respawnPoint;
    public GameObject playerPrefab;

    public CinemachineVirtualCamera cam;

    private void Awake()
    {
        instance = this;
    }

    private void Respawn()
    {
        GameObject player = Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
        cam.Follow = player.transform;
    }

    public void WaitRespawn()
    {
        StartCoroutine("RespawnAfterSeconds", 1f);
    }

    IEnumerator RespawnAfterSeconds(float delay)
    {
        yield return new WaitForSeconds(delay);
        EnemyManager.instance.Respawn();
        Respawn();
    }
}
