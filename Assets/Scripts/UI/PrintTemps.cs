using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrintTemps : MonoBehaviour
{
    public TMP_Text MyText;

    // Start is called before the first frame update
    void Start()
    {
        MyText.text = "Time : " + IA.Temps;
        IA.Temps = 0;
    }
}
