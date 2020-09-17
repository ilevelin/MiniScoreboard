using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerColorController : MonoBehaviour
{
    [SerializeField] GameObject selectedCross;
    [SerializeField] Image[] bettingImages;
    [SerializeField] Image scoreImage;

    public int playerColor = 1;
    Color finalColor = new Color();

    private void Start()
    {
        UpdateColor(playerColor);
    }

    void Update()
    {
        selectedCross.transform.localPosition = new Vector3(-400 + ((playerColor - 1) * 35), 5.5f);
    }

    public void UpdateColor(int newColor)
    {
        playerColor = newColor;
        switch (playerColor)
        {
            case 1:
                finalColor = new Color(0,0,.8f);
                break;
            case 2:
                finalColor = new Color(.8f,0,0);
                break;
            case 3:
                finalColor = new Color(0,.8f,0);
                break;
            case 4:
                finalColor = new Color(.8f,.8f,0);
                break;
            case 5:
                finalColor = new Color(0,.8f, .8f);
                break;
            case 6:
                finalColor = new Color(.8f, 0, .8f);
                break;
            case 7:
                finalColor = new Color(.4f, .4f, .4f);
                break;
            case 8:
                finalColor = new Color(.8f, .4f, 0);
                break;
        }

        float
            r = finalColor.r / 5,
            g = finalColor.g / 5,
            b = finalColor.b / 5;
        for (int i = 0; i < bettingImages.Length; i++)
            bettingImages[i].color = new Color(finalColor.r - (r * i), finalColor.g - (g * i), finalColor.b - (b * i));
        scoreImage.color = finalColor;
    }
}
