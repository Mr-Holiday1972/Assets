using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadingControll2 : MonoBehaviour
{
    public Text text;
    private bool bbb;
    Coroutine myCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        bbb = true;
    }
    
    void Update()
    {
        if (bbb == true)
        {
            myCoroutine = StartCoroutine(Load());
        }
    }   

    // Update is called once per frame
    IEnumerator Load()
    {
        bbb = false;
        text.text = "Loading";
        yield return new WaitForSeconds(1);
        text.text = "Loading.";
        yield return new WaitForSeconds(1);
        text.text = "Loading..";
        yield return new WaitForSeconds(1);
        text.text = "Loading...";
        yield return new WaitForSeconds(1);
        bbb = true;
    }
}
