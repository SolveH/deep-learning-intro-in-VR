using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRotator : MonoBehaviour
{
    private float rotationSpeed = 0.3f;
    Quaternion doorClosed = Quaternion.Euler(0, 0, 0);
    Quaternion doorOpen = Quaternion.Euler(0, -150, 0);
    Quaternion currentAngle;


    // Start is called before the first frame update
    void Start()
    {
        currentAngle = doorClosed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, currentAngle, Time.deltaTime * rotationSpeed);
    }
    public void OpenDoor()
    {
        currentAngle = doorOpen;
    }
    public void CloseDoor()
    {
        currentAngle = doorClosed;
    }
}
