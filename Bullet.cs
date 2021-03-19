using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    private FireManager fireManager;
    [SerializeField] private int damage = 2;
    // Start is called before the first frame update
    void Start()
    {
        fireManager = FindObjectOfType<FireManager>();
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.forward * fireManager.speed);
        Debug.LogWarning(Vector3.forward);
        Destroy(gameObject,2);
    }

    void FixedUpdate()
    {

    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.SendMessage("Die", damage);
        }
    }
}
