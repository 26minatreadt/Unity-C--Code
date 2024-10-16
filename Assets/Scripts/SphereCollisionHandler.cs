using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCollisionHandler : MonoBehaviour
{
    // This method is called when the collider attached to this GameObject collides with another collider
    void OnCollisionEnter(Collision collision)
    {
        // Check if the object we collided with has the "Cube" tag
        if (collision.gameObject.CompareTag("Cube"))
        {
            // Log a message to the console
            Debug.Log("Sphere collided with Cube!");
            // You can add additional logic here, such as applying damage or triggering an event
        }
    }

    // This method is called when the trigger collider attached to this GameObject intersects with another collider
    void OnTriggerEnter(Collider other)
    {
        // Check if the object we triggered with has the "Cube" tag
        if (other.CompareTag("Cube"))
        {
            // Log a message to the console
            Debug.Log("Sphere triggered with Cube!");
            // You can add additional logic here specific to cube trigger events
        }
    }
}
