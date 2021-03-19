using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;
    [SerializeField] private int min = -5;
    [SerializeField] private int max = 5;
    public float time = 5;

    private GameObject player;
    private GameObject spawned;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Spawn()
    {
        //if (!player.activeSelf)
            //gameObject.SetActive(false);
        Vector3 spawnPos = new Vector3(transform.position.x + Random.Range(min, max), transform.position.y, transform.position.z + Random.Range(min, max));
        spawned = Instantiate<GameObject>(Enemy, spawnPos, Enemy.transform.rotation);
        Invoke("Spawn", time);
    }
}
