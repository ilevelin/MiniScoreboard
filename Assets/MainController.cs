using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public enum AoEColor
{
    BLUE, RED, GREEN, YELLOW, CYAN, PURPLE, GREY, ORANGE
}

public class MainController : MonoBehaviour
{
    string player1name, player2name;
    int player1score, player2score;
    AoEColor player1color, player2color;
    public int[] bytcs = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
    public int[] ludopatas = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
    public int totalbytcs, totalludopatas;
    public float[] percentbytcs = new float[8] { 0, 0, 0, 0, 0, 0, 0, 0 }, percentludopatas = new float[8] { 0, 0, 0, 0, 0, 0, 0, 0 };

    [SerializeField]
    TMP_InputField p1name, p2name, p1score, p2score,
        w0b, w0l, w1b, w1l, w2b, w2l, w3b, w3l,
        l0b, l0l, l1b, l1l, l2b, l2l, l3b, l3l;

    [SerializeField]
    TextMeshProUGUI scp1name, scp2name, scp1score, scp2score;
    
    void Start()
    {
        
    }

    private void Update()
    {
        /* Basic */
        player1name = p1name.text;
        player2name = p2name.text;

        if (int.TryParse(p1score.text, out player1score))
            p1score.textComponent.color = Color.black;
        else
            p1score.textComponent.color = Color.red;

        if (int.TryParse(p2score.text, out player2score))
            p2score.textComponent.color = Color.black;
        else
            p2score.textComponent.color = Color.red;

        /* Bettings */
        if (int.TryParse(w0b.text, out bytcs[0]))
            w0b.textComponent.color = Color.black;
        else
            w0b.textComponent.color = Color.red;
        if (int.TryParse(w1b.text, out bytcs[1]))
            w1b.textComponent.color = Color.black;
        else
            w1b.textComponent.color = Color.red;
        if (int.TryParse(w2b.text, out bytcs[2]))
            w2b.textComponent.color = Color.black;
        else
            w2b.textComponent.color = Color.red;
        if (int.TryParse(w3b.text, out bytcs[3]))
            w3b.textComponent.color = Color.black;
        else
            w3b.textComponent.color = Color.red;
        if (int.TryParse(l3b.text, out bytcs[4]))
            l3b.textComponent.color = Color.black;
        else
            l3b.textComponent.color = Color.red;
        if (int.TryParse(l2b.text, out bytcs[5]))
            l2b.textComponent.color = Color.black;
        else
            l2b.textComponent.color = Color.red;
        if (int.TryParse(l1b.text, out bytcs[6]))
            l1b.textComponent.color = Color.black;
        else
            l1b.textComponent.color = Color.red;
        if (int.TryParse(l0b.text, out bytcs[7]))
            l0b.textComponent.color = Color.black;
        else
            l0b.textComponent.color = Color.red;

        if (int.TryParse(w0l.text, out ludopatas[0]))
            w0l.textComponent.color = Color.black;
        else
            w0l.textComponent.color = Color.red;
        if (int.TryParse(w1l.text, out ludopatas[1]))
            w1l.textComponent.color = Color.black;
        else
            w1l.textComponent.color = Color.red;
        if (int.TryParse(w2l.text, out ludopatas[2]))
            w2l.textComponent.color = Color.black;
        else
            w2l.textComponent.color = Color.red;
        if (int.TryParse(w3l.text, out ludopatas[3]))
            w3l.textComponent.color = Color.black;
        else
            w3l.textComponent.color = Color.red;
        if (int.TryParse(l3l.text, out ludopatas[4]))
            l3l.textComponent.color = Color.black;
        else
            l3l.textComponent.color = Color.red;
        if (int.TryParse(l2l.text, out ludopatas[5]))
            l2l.textComponent.color = Color.black;
        else
            l2l.textComponent.color = Color.red;
        if (int.TryParse(l1l.text, out ludopatas[6]))
            l1l.textComponent.color = Color.black;
        else
            l1l.textComponent.color = Color.red;
        if (int.TryParse(l0l.text, out ludopatas[7]))
            l0l.textComponent.color = Color.black;
        else
            l0l.textComponent.color = Color.red;

        totalbytcs = 0;
        foreach (int a in bytcs)
            totalbytcs += a;

        totalludopatas = 0;
        foreach (int l in ludopatas)
            totalludopatas += l;

        for (int i = 0; i < bytcs.Length; i++)
        {
            percentbytcs[i] = ((float)bytcs[i]) / ((float)totalbytcs);
            percentludopatas[i] = ((float)ludopatas[i]) / ((float)totalludopatas);
        }
    }

    public void UpdateInterface()
    {
        scp1name.text = player1name;
        scp2name.text = player2name;
        scp1score.text = player1score.ToString();
        scp2score.text = player2score.ToString();
    }

    public void PlayerWins(int i)
    {
        if (i == 1)
        {
            player1score++;
            scp1score.text = player1score.ToString();
            p1score.text = player1score.ToString();
        }
        else if (i == 2)
        {
            player2score++;
            scp2score.text = player2score.ToString();
            p2score.text = player2score.ToString();
        }
    }
}
