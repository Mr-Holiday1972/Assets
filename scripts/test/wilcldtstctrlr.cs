using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class OriginalAxleInfoo {
    public Rigidbody leftWheel;
    public Rigidbody rightWheel;
    public bool motor;
    public bool steering;
}
     
public class wilcldtstctrlr : MonoBehaviour {
    public List<OriginalAxleInfoo> axleInfos; 
    public float maxMotorTorque;
    public float maxSteeringAngle;

    public float motor;
    public float steering;

    public Transform wltrsfm;
    public Transform bdy;
    public Vector3 strg;
    public Vector3 bdyyrt;//bdy y rot
    public Rigidbody lstrg;
    public Rigidbody rstrg;

    public void FixedUpdate()
    {
        motor = maxMotorTorque * Input.GetAxis("Vertical");
        steering = maxSteeringAngle * Input.GetAxis("Horizontal");
     
        foreach (OriginalAxleInfoo axleInfo in axleInfos) {
            // wltrsfm = axleInfo.leftWheel.transform;
            bdyyrt = bdy.localEulerAngles;

            // strg = wltrsfm.localEulerAngles;
            // strg.y = steering;
            if (axleInfo.steering)
            {
                //rotation
                // axleInfo.leftWheel.rotation = Quaternion.AngleAxis(bdyyrt.y + steering, Vector3.up);
                // axleInfo.rightWheel.rotation = Quaternion.AngleAxis(bdyyrt.y + steering, Vector3.up);


                //angular velocity
                // Vector3 angularVelocityl = axleInfo.leftWheel.angularVelocity;
                // Vector3 angularVelocityr = axleInfo.rightWheel.angularVelocity;
                // angularVelocityl.y = bdyyrt.y + steering;  // Adjust y rotation slowly
                // angularVelocityr.y = bdyyrt.y + steering;
                // axleInfo.leftWheel.angularVelocity = angularVelocityl;
                // axleInfo.rightWheel.angularVelocity = angularVelocityr;

                
                //quaternion
                // Quaternion currentRotationl = axleInfo.leftWheel.rotation;
                // Quaternion currentRotationr = axleInfo.rightWheel.rotation;
                // Quaternion targetRotationl = Quaternion.Euler(currentRotationl.eulerAngles.x, (bdyyrt.y + steering), currentRotationl.eulerAngles.z);
                // Quaternion targetRotationr = Quaternion.Euler(currentRotationr.eulerAngles.x, (bdyyrt.y + steering), currentRotationr.eulerAngles.z);
                
                // axleInfo.leftWheel.MoveRotation(targetRotationl);
                // axleInfo.rightWheel.MoveRotation(targetRotationr);


                //rigidbody
                // lstrg.AddTorque(transform.up * steering);
                // rstrg.AddTorque(transform.up * steering);


                //scraps
                // axleInfo.leftWheel.AddTorque(transform.up * (bdyyrt.y + steering));
                // axleInfo.rightWheel.AddTorque(transform.up * (bdyyrt.y + steering));

                // Vector3 lflocalVelocity = transform.InverseTransformDirection(axleInfo.leftWheel.velocity);
                // Vector3 rflocalVelocity = transform.InverseTransformDirection(axleInfo.rightWheel.velocity);
                
                // lflocalVelocity.x = 0;
                // lflocalVelocity.z = 0;
                // rflocalVelocity.x = 0;
                // rflocalVelocity.z = 0;

                // axleInfo.leftWheel.velocity = transform.TransformDirection(lflocalVelocity);
                // axleInfo.rightWheel.velocity = transform.TransformDirection(rflocalVelocity);
            }

            if (axleInfo.motor)
            {
                axleInfo.rightWheel.AddTorque(transform.right * motor);
                axleInfo.leftWheel.AddTorque(transform.right * motor);

                // Vector3 lrlocalVelocity = transform.InverseTransformDirection(axleInfo.leftWheel.velocity);
                // Vector3 rrlocalVelocity = transform.InverseTransformDirection(axleInfo.rightWheel.velocity);
                
                // lrlocalVelocity.x = 0;
                // lrlocalVelocity.z = 0;
                // rrlocalVelocity.x = 0;
                // rrlocalVelocity.z = 0;
                
                // axleInfo.leftWheel.velocity = transform.TransformDirection(lrlocalVelocity);
                // axleInfo.rightWheel.velocity = transform.TransformDirection(rrlocalVelocity);
            }
        }
    }
}