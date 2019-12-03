using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffecup : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //If coffeecup is moved too far away, position is reset
        if (Vector3.Distance(transform.position, new Vector3(2.023f, 1.099f, -2.896f)) > 0.8)
        {
            Destroy(this.gameObject);
        }
    }
}
