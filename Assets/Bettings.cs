using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bettings : MonoBehaviour
{
    [SerializeField] MainController mainController;
    [SerializeField] RectTransform w0i, w1i, w2i, w3i, l3i, l2i, l1i, l0i;
    [SerializeField] TextMeshProUGUI w0t, w1t, w2t, w3t, l3t, l2t, l1t, l0t, info;
    int[] objectiveSize = new int[8] { -1, -1, -1, -1, -1, -1, -1, -1 };
    int[] values = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
    Color objectiveColor = Color.black;
    TextMeshProUGUI[] labels;
    RectTransform[] squares;

    public void Start()
    {
        labels = new TextMeshProUGUI[8] { w0t, w1t, w2t, w3t, l3t, l2t, l1t, l0t };
        squares = new RectTransform[8] { w0i, w1i, w2i, w3i, l3i, l2i, l1i, l0i };
    }

    public void ShowBYTCS()
    {
        for (int i = 0; i < objectiveSize.Length; i++)
        {
            objectiveSize[i] = (int) (mainController.percentbytcs[i] * 640);
            values[i] = mainController.bytcs[i];
        }
        info.text = "BYTCS APOSTADOS (TOTALES = " + mainController.totalbytcs + ")";
    }

    public void ShowLudopatas()
    {
        for (int i = 0; i < objectiveSize.Length; i++)
        {
            objectiveSize[i] = (int) (mainController.percentludopatas[i] * 640);
            values[i] = mainController.ludopatas[i];
        }
        info.text = "PERSONAS APOSTANDO (TOTALES = " + mainController.totalludopatas + ")";
    }

    public void HideAnything()
    {
        for (int i = 0; i < objectiveSize.Length; i++)
        {
            objectiveSize[i] = 0;
            values[i] = 0;
        }
    }

    public void Update()
    {
        for (int i = 0; i < labels.Length; i++)
        {
            if (values[i] == 0)
                labels[i].text = "";
            else
                labels[i].text = values[i].ToString();
            squares[i].sizeDelta = new Vector2(Mathf.Lerp(squares[i].sizeDelta.x, objectiveSize[i], Time.deltaTime * 5), squares[i].sizeDelta.y);
        }
    }

}
