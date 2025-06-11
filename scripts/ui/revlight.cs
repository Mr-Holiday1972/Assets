using UnityEngine;
using System.Collections;

public class revlight : MonoBehaviour
{
    public Material off; // Drag your first material here in the Inspector.
    public Material on; // Drag your second material here in the Inspector.
    public SimpleCarController SCCRef;
    private float nnnn;

    private Renderer objectRenderer;
    //private bool isMaterial1Active = true;

    void Start()
    {
        // Get the Renderer component attached to this GameObject.
        objectRenderer = GetComponent<Renderer>();

        // Initially, set the object's material to material1.
        objectRenderer.material = off;
    }

    void Update()
    {
        nnnn = SCCRef.fff;
        // Check for a user input or any condition that triggers material change.
        if (nnnn == -1) // Example: Change on pressing the Space key.
        {
            objectRenderer.material = on;
        }
        else
        {
            objectRenderer.material = off;
        }
    }
}