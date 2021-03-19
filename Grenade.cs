using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private int Damage = 7;
    [SerializeField] private float Range = 5;

    private GameObject[] enemies; 
    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Invoke("Explosion", 3);
        Destroy(gameObject, 4);
    }

    void Explosion()
    {
        for(int i = 0; i < enemies.Length - 1; i++)
            if (Vector3.Distance(transform.position, enemies[i].transform.position) <= Range)
                enemies[i].SendMessage("Die", Damage);
    }
}
