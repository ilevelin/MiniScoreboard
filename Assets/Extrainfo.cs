using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class Extrainfo : MonoBehaviour
{
    [SerializeField] Image logoDisplay;
    [SerializeField] TextMeshProUGUI label, fullError;
    [SerializeField] TMP_InputField[] inputs;
    [SerializeField] Toggle showLogo;
    [SerializeField] Text showLogoText;
    
    bool logoAvaliable = true;
    string[] strings;
    int state = 0;

    void Start()
    {
        try
        {
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(File.ReadAllBytes("./Logo.png"));
            logoDisplay.sprite = Sprite.Create(texture, new Rect(0.0f,0.0f,texture.width,texture.height), new Vector2(0.5f, 0.5f));
        }
        catch
        {
            showLogoText.text = "Couldn't find Logo.png";
            fullError.text = "Couldn't find " + Path.GetFullPath("./Logo.png");
            showLogoText.color = Color.red;
            logoAvaliable = false;
        }

        strings = new string[inputs.Length];
    }

    private void Update()
    {
        for (int i = 0; i < inputs.Length; i++)
            strings[i] = inputs[i].text;
    }

    public void ShowNext()
    {
        int nextState = state + 1;
        while (true)
        {
            if (nextState > inputs.Length) nextState = 0;
            if (nextState == state) break;
            if (nextState == 0)
            {
                if (showLogo.isOn && logoAvaliable)
                {
                    logoDisplay.color = Color.white;
                    label.color = new Color(1, 1, 1, 0);
                    state = nextState;
                    break;
                }
            }
            else
            {
                if (strings[nextState - 1] != "") 
                {
                    logoDisplay.color = new Color(1, 1, 1, 0);
                    label.color = Color.white;
                    state = nextState;
                    label.text = strings[state - 1];
                    break;
                }
            }
            nextState++;
        }
    }
}
