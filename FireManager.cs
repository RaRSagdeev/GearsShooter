using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    [SerializeField] private float Speed = 10;
    [SerializeField] private GameObject Grenade;
    public float Power = 5;
    public readonly float speed;
    public GameObject player;

    private CursorScript cursor;

    public FireManager()
    {
        speed = Speed;
    }

    
    // Start is called before the first frame update
    void Start()
    {
        cursor = FindObjectOfType<CursorScript>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
            ThrowGrenade();
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Fire();
    }
    void Fire()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit,100f))
        {
            hit.transform.gameObject.SendMessage("Die", 2);
        }
    }
    void ThrowGrenade()
    {
        float rX, rZ, rP;
        Vector3 forward = cursor.transform.position - transform.position;
        rP = Random.Range(-5, 5); rX = Random.Range(-0.5f, 0.5f); rZ = Random.Range(-0.5f, 0.5f);
        var grenade = Instantiate<GameObject>(Grenade, player.transform.position, Quaternion.LookRotation(new Vector3(-forward.x, 0, -forward.z)));
        var grenadeRb = grenade.GetComponent<Rigidbody>();
        grenadeRb.AddForce(new Vector3(0f, 1.5f, 0f) * (Power));
    }
}
