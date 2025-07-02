//＊Insert a comment here*＊
//
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//a list of fields to collect general information about each axle and its wheels
[System.Serializable]
public class OriginalAxleInfo {
    public Rigidbody leftWheel;
    public Rigidbody rightWheel;
    public bool motor;
    //public bool steering;
}

//a list of fields that refers to all steering mechanism unit that has been implemented on the vehicle
[System.Serializable]
public class OriginalSteeringMechanismInfo {
    public ArticulationBody steeringMechanism;
    public bool reverse;
}
     
public class WheelColliderTestController : MonoBehaviour {
    public List<OriginalAxleInfo> axleInfos;
    public List<OriginalSteeringMechanismInfo> steeringMechanismInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;

    public float motor;
    public float steering;

    // public Transform wltrsfm;
    // public Transform bdy;
    // public Vector3 strg;
    //public Vector3 bdyyrt;//bdy y rot
    // public Rigidbody lstrg;
    // public Rigidbody rstrg;

    // public Transform y1;//get the parent from the axle info list
    // public Transform y2;
    // public Vector3 y1v;//y1 variable
    // public Vector3 y2v;

    public void FixedUpdate()
    {
        //takes the input
        motor = maxMotorTorque * Input.GetAxis("Vertical");
        steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        //controls the wheel's motor/steering
        //motor
        foreach (OriginalAxleInfo axleInfo in axleInfos)
        {
            // wltrsfm = axleInfo.leftWheel.transform;
            //bdyyrt = bdy.localEulerAngles;

            // strg = wltrsfm.localEulerAngles;
            // strg.y = steering;
            //if (axleInfo.steering)
            //{
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

                //simple method
                //rigidbody(y rotation)
                //----wheel rigidbody(x rotation)
                // y1.rotation = Quaternion.AngleAxis(steering, Vector3.up);
                // y2.rotation = Quaternion.AngleAxis(steering, Vector3.up);


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

                // y1v = y1.rotation;//getting the refernced object'S position
                // y2v = y2.rotation;

                // y1v.y = steering;//applying the value to the steering (do the ackerman stuff later!)
                // y2v.y = steering;

                // y1.position =y1v
                // y2.position =y2v

                //controls the steering-arm's y rotation (the optimised version's arm)
            //}

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
        //steering
        foreach (OriginalSteeringMechanismInfo steeringMechanismInfo in steeringMechanismInfos)
        {
            var yValue = steeringMechanismInfo.steeringMechanism.yDrive;
            if (!steeringMechanismInfo.reverse)
            {
                yValue.target = steering;
            }
            else
            {
                yValue.target = steering - (steering * 2);
            }
            steeringMechanismInfo.steeringMechanism.yDrive = yValue;
        }
    }
}