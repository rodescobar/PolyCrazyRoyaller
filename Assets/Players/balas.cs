using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balas : MonoBehaviour
{
    private Rigidbody rb;
    public float fps;

    private float lifeTime = 10f;
    private float  time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        Destroy(gameObject,5f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * fps;
    }

    void OnTriggerEnter(Collider col) {
        if(col.gameObject.CompareTag("Objetos")) {
           Destroy(gameObject);
        }
    }
}
