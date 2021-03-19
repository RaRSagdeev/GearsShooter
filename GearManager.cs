using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearManager : MonoBehaviour
{
    private Rigidbody rb;
    private MoveManager manager;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        manager = GetComponent<MoveManager>();
    }

    void PickUp()
    {
        Destroy(gameObject);
    }
    void Update()
    {
        gameObject.transform.Rotate(0, 0, 2);
        Ray ray = new Ray(gameObject.transform.position, Vector3.back);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit, 2f))
        {
            hit.transform.gameObject.SendMessage("Collect", gameObject);
        }
        ray = new Ray(gameObject.transform.position, Vector3.left);
        if (Physics.Raycast(ray, out hit, 2f))
        {
            hit.transform.gameObject.SendMessage("Collect", gameObject);
        }
        ray = new Ray(gameObject.transform.position, Vector3.right);
        if (Physics.Raycast(ray, out hit, 2f))
        {
            hit.transform.gameObject.SendMessage("Collect", gameObject);
        }
        ray = new Ray(gameObject.transform.position, Vector3.forward);
        if (Physics.Raycast(ray, out hit, 2f))
        {
            hit.transform.gameObject.SendMessage("Collect", gameObject);
        }
    }
}
