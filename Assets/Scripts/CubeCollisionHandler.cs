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
        cubeRenderer.material.color = collisionColor;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sphere"))
            Debug.Log("Cube collided with Sphere!");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sphere"))
            Debug.Log("Cube triggered with Sphere!");
    }
}
