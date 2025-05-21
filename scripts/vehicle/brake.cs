using UnityEngine;
using System.Collections;

public class brake : MonoBehaviour
{
    public Rigidbody rb;
    public float www; 
    public Material off;
    public Material on;

    private Renderer objectRenderer;
    //private bool isMaterial1Active = true;

    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
        objectRenderer = GetComponent<Renderer>();

        objectRenderer.material = off;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.S))//==========
        {
            objectRenderer.material = on;

            if (www < 2 && rb.velocity.magnitude > 1)
            {
                www += 0.1f;
            }
        }
        else
        {
            objectRenderer.material = off;
            if (www > 0)
            {
                www -= 0.1f;
            }
        }

        if (rb.velocity.magnitude < 1)
        {
            if (www > 0)
            {
                www -= 0.1f;
            }
        }

        GetComponent<AudioSource>().volume = www;
    }
}