using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset : MonoBehaviour
{
    //private int lll;
    public Rigidbody rb;
    private Vector3 setPosition;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OBJ"))
        {
            setPosition = other.transform.position;
        }
    }

    // Update is called once per frame
    private void OnCollisionStay(Collision collision)
    {
        Transform myTransform = this.transform;
        Vector3 localAngle = myTransform.localEulerAngles;
        Vector3 pos = setPosition;

        if (collision.gameObject.tag == "terrain")
        {
            if (Input.GetKeyDown(KeyCode.R))//==========
            {
                localAngle.z = 0.0f;
                pos.y += 18.0f;
                myTransform.localEulerAngles = localAngle;
                this.transform.position = pos;
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, 0);
            }
        }
    }
}