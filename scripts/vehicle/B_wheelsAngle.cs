using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_wheelsAngle : MonoBehaviour
{
    public float nnn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Access the object's Transform component.
        Transform objectTransform = transform; // "transform" is a reference to the Transform of the GameObject this script is attached to.
        // Get the object's world rotation in Euler angles.
        Vector3 worldRotation = objectTransform.rotation.eulerAngles;

        nnn = worldRotation.y;

        //Debug.Log(nnn);
    }
}
