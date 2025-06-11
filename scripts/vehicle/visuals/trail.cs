using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trail : MonoBehaviour
{
    public bool drift;
    public TrailRenderer[] TM;
    private Rigidbody rb;
    private int mmm;
    public TrailRenderer[] brakeMarks;
    //public B_wheelsAngle BWARef;
    //public SimpleCarController SCVRef;
    //private Vector3 lastPosition;
    //private float nnnn;
    //private float www;

    //    // Start is called before the first frame update
    //    void Start()
    //    {
    //        lastPosition = transform.position;
    //    }

    //    // Update is called once per frame
    //    void Update()
    //    {
    //        // Calculate the direction of movement.
    //        Vector3 currentPosition = transform.position;
    //        Vector3 movementDirection = currentPosition - lastPosition;
    //        // Calculate the angle of rotation around the Y-axis.
    //        float worldRotation = Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg;
    //        // Update the last position for the next frame.
    //        lastPosition = currentPosition;
    //        // Display the world rotation as a single number.
    //        //Debug.Log("World Rotation: " + worldRotation);

    //        nnnn = BWARef.nnn;
    //        if (Mathf.Abs(nnnn - worldRotation) >= 30)
    //        {
    //        }
    //        else
    //        {
    //        }
    //        //Debug.Log(worldRotation);
    //        //Debug.Log(nnnn);
    //    }
    //}

    void Start()
    {
        // Get the Rigidbody component attached to the car
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Calculate the dot product between the car's forward vector and its velocity vector
        float dotProduct = Vector3.Dot(transform.forward.normalized, rb.velocity.normalized);

        // Determine the direction based on the dot product value
        if (dotProduct > 0.8f)
        {
            drift = false;
            if (mmm > 0)
            {
                mmm -= 1;
            }
        }
        else if (dotProduct < -0.8f)
        {
            //reverse
            drift = false;
            if (mmm > 0)
            {
                mmm -= 1;
            }
        }
        else
        {
            if (rb.velocity.magnitude > 1)
            {
                //sliding
                drift = true;
                if (mmm < 40)
                {
                    mmm += 1;
                }
            }
        }


        if (drift) { startEmitter(); }
        else if (mmm <= 15)
        {
            stopEmitter();
        }

        if (Input.GetKey(KeyCode.S))//==========
        {
            brakeEmitt();
        }
        else
        {
            brakeUnEmitt();
        }
    }

    private void startEmitter()
    {
        foreach(TrailRenderer T in TM)
        {
            T.emitting = true;
        }
    }

    private void stopEmitter()
    {
        foreach (TrailRenderer T in TM)
        {
            T.emitting = false;
        }
    }

    private void brakeEmitt()
    {
        foreach(TrailRenderer T in brakeMarks)
        {
            T.emitting = true;
        }
    }

    private void brakeUnEmitt()
    {
        foreach(TrailRenderer T in brakeMarks)
        {
            T.emitting = false;
        }
    }
} 