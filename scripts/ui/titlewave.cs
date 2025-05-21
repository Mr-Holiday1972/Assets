using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titlewave : MonoBehaviour
{
    private float rrr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rrr = Random.Range(0.1f, 5.0f);
    }
}
