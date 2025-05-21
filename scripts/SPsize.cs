using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SPsize : MonoBehaviour
{
    public int rrr;
    public int uuu;
    public uicont UCRef;
    private int qqqq;
    private RectTransform rt;
    public Button uiButton; // Reference to the UI button you want to move.
    Vector2 newPosition;

    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        qqqq = UCRef.qqq;

        if (qqqq == rrr)
        {
            var targetSize = new Vector2(176, 33);
            Vector2 targetTrans = new Vector2(-300, uuu);
            rt.sizeDelta = targetSize;

            // Get the RectTransform of the UI button.
            RectTransform buttonRectTransform = uiButton.GetComponent<RectTransform>();

            // Set the new position.
            buttonRectTransform.anchoredPosition = targetTrans;
        }
        else
        {
            var targetSize = new Vector2(160, 30);
            Vector2 targetTrans = new Vector2(-330, uuu);
            rt.sizeDelta = targetSize;

            // Get the RectTransform of the UI button.
            RectTransform buttonRectTransform = uiButton.GetComponent<RectTransform>();

            // Set the new position.
            buttonRectTransform.anchoredPosition = targetTrans;
        }
    }
}