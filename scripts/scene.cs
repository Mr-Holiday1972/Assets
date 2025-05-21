using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Title", 3.47f);
    }

    // Update is called once per frame
    void Title()
    {
        SceneManager.LoadScene("title");
    }
}
