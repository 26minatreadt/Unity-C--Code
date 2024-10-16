using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollisionHandler : MonoBehaviour
{
    private Renderer cubeRenderer;
    public Color collisionColor = Color.red;
    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        cubeRenderer.material.color = collisionColor; // Set the initial color of the cube
    }

    // This method is called when the collider attached to this GameObject collides with another collider
    void OnCollisionEnter(Collision collision)
    {
        // Check if the object we collided with has the "Sphere" tag
        if (collision.gameObject.CompareTag("Sphere"))
        {
            // Log a message to the console
            Debug.Log("Cube collided with Sphere!");
            // You can add additional logic here specific to sphere collisions
        }
    }
    // This method is called when the trigger collider attached to this GameObject intersects with another collider
    void OnTriggerEnter(Collider other)
    {
        // Check if the object we triggered with has the "Sphere" tag
        if (other.CompareTag("Sphere"))
        {
            // Log a message to the console
            Debug.Log("Cube triggered with Sphere!");
            // You can add additional logic here specific to sphere trigger events
        }
    }
}
