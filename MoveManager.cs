using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class MoveManager : MonoBehaviour
{
    private NavMeshAgent controller;
    private CursorScript cursor;

    public Text HPText;
    public Text GameOverText;
    public Text VictoryText;
    public int HP = 20;
    public float Speed = 5f;
    public Text MyText;

    private int gears = 0;

    void Start()
    {
        cursor = FindObjectOfType<CursorScript>();
        controller = GetComponent<NavMeshAgent>();
        controller.updateRotation = false;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 forward = cursor.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(new Vector3(forward.x, 0, forward.z));
        Vector3 dir = Vector3.zero;
        if (Input.GetKey(KeyCode.S))
            dir.z = -1.0f;
        if (Input.GetKey(KeyCode.W))
            dir.z = 1.0f;
        if (Input.GetKey(KeyCode.A))
            dir.x = -1.0f;
        if (Input.GetKey(KeyCode.D))
            dir.x = 1.0f;
        controller.velocity = dir.normalized * Speed;
    }

    void Collect(GameObject col)
    {
            gears++;
            MyText.GetComponent<Text>().text = "Gears:" + gears + "/10";
            col.gameObject.SendMessage("PickUp");
        if(gears == 10)
        {
            VictoryText.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
    void Die(int damage)
    {
        HP -= damage;
        HPText.text = "HP:" + HP + "/20";
        if (HP == 0)
            GameOver();
    }
    void GameOver()
    {
        GameOverText.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
