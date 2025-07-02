using UnityEngine;

public class articulationBodyTest : MonoBehaviour
{
    public ArticulationBody[] articulationBodies;
    public Rigidbody wheel;
    public ArticulationBody steeringMehcanisms;

    // 定期的に呼ばれる
    void FixedUpdate()
    {
        //controls the wheel-"arm"'s rotation
        //forward
        if (Input.GetKey(KeyCode.Q))
        {
            var xDrive = this.articulationBodies[2].xDrive;//gets the current articulation bosy's target value
            xDrive.target -= 10f;//changes the target value to however
            this.articulationBodies[2].xDrive = xDrive;//applies the changed value

            //the same logic applies to the rest of the arm-controling lines
        }
        //backward
        else if (Input.GetKey(KeyCode.E))
        {
            var xDrive = this.articulationBodies[2].xDrive;
            xDrive.target += 10f;
            this.articulationBodies[2].xDrive = xDrive;
        }
        
        var yValue = this.articulationBodies[1].yDrive;
        //controls the steering-arm's y rotation
        //forward
        if (Input.GetKey(KeyCode.A) && !(yValue.target <= -35))
        {
            yValue.target -= 1f;
            this.articulationBodies[1].yDrive = yValue;
        }
        //backward
        else if (Input.GetKey(KeyCode.D) && !(yValue.target >= 35))
        {
            yValue.target += 1f;
            this.articulationBodies[1].yDrive = yValue;
        }

        //gives a gas to and rotates the actual wheel
        if (Input.GetKey(KeyCode.W))
        {
            wheel.AddTorque(0, 0, 10f);
        }
    }
}