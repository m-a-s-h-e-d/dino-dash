using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    public Transform[] respawnPoints;
    public GameObject[] enemyPrefabs;

    private void Awake()
    {
        instance = this;
    }

    public void Respawn()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(go);
        }
        foreach (var point in respawnPoints)
        {
            int randomNum = UnityEngine.Random.Range(0, 2);
            Instantiate(enemyPrefabs[randomNum], point.position, Quaternion.identity);
        }
    }
}
