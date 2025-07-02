using UnityEngine;

public class articulationBodyTest : MonoBehaviour
{
    public ArticulationBody[] articulationBodies;
    public Rigidbody wheel;
    public ArticulationBody steeringMehcanisms;

    // 定期的に呼ばれる
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            var xDrive = this.articulationBodies[2].xDrive;
            xDrive.target -= 10f;
            this.articulationBodies[2].xDrive = xDrive;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            var xDrive = this.articulationBodies[2].xDrive;
            xDrive.target += 10f;
            this.articulationBodies[2].xDrive = xDrive;
        }

        
        else if (Input.GetKey(KeyCode.A))
        {
            var yValue = this.articulationBodies[1].yDrive;
            yValue.target -= 1f;
            this.articulationBodies[1].yDrive = yValue;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            var yValue = this.articulationBodies[1].yDrive;
            yValue.target += 1f;
            this.articulationBodies[1].yDrive = yValue;
        }

        if (Input.GetKey(KeyCode.W))
        {
            wheel.AddTorque(0, 0, 10f);
        }
    }
}