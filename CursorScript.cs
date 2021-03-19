using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    int layerMask;
    // Start is called before the first frame update
    void Start()
    {
        layerMask = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, layerMask))
            transform.position = new Vector3(hit.point.x, transform.position.y, hit.point.z);
    }
}
