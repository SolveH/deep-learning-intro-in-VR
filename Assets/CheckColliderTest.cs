using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckColliderTest : MonoBehaviour
{



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision with " + other.name);
    }
}
