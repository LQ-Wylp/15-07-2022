using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrintDifficulty : MonoBehaviour
{
    public TMP_Text MyText;

    // Start is called before the first frame update
    void Start()
    {
        MyText.text = "Difficulty : " + SwapPlayer.Difficulte;
        SwapPlayer.Difficulte = 0;
    }

}
