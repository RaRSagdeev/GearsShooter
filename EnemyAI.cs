using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private GameObject gear;
    [SerializeField] private int HP = 10;
    [SerializeField] private Transform player;
    [SerializeField] private float Range = 5;

    private NavMeshAgent controller;
    private MoveManager playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = FindObjectOfType<MoveManager>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        controller = GetComponent<NavMeshAgent>();
        controller.updateRotation = false;
    }
    // Update is called once per frame
    void Update()
    {
        controller.SetDestination(player.position);
        transform.rotation = Quaternion.LookRotation(controller.velocity.normalized);
        if (Vector3.Distance(transform.position, player.position) <= Range && playerScript.HP > 0)
            Invoke("Kill", 4);
    }

    void Kill()
    {
        player.gameObject.SendMessage("Die", 1);
    }

    public void Die(int dmg)
    {
        HP -= dmg;
        if (HP <= 0)
        {
            var trans = gameObject.transform;
            var pos = new Vector3(trans.position.x, trans.position.y + 0.9f, trans.position.z);
            Destroy(gameObject);
            Instantiate(gear, pos, gear.transform.rotation);
        }
    }
}