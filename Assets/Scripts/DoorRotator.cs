using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRotator : MonoBehaviour
{
    private float rotationSpeed = 0.01f;
    private float y = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(y > -150)
        {
            y += Time.deltaTime * -20;
            transform.rotation = Quaternion.Euler(0, y, 0);
        }
    }
}
