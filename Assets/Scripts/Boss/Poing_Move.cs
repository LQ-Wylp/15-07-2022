using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poing_Move : MonoBehaviour
{
    public float _Speed = 1;
    public float _PosY;
    public float _PosMaxX;

    private int PhaseInt = 1;

    public float DurationPhase2;
    private float Timer;

    public GameObject ChocWaveDroite;
    public GameObject ChocWaveGauche;

    // Update is called once per frame
    void Update()
    {
        // Phase 1
        if(PhaseInt == 1)
        {
            if(transform.position.y > _PosY)
            {
                transform.position -= new Vector3(0, 1, 0) * _Speed * Time.deltaTime;
            }
            else
            {
                Instantiate(ChocWaveDroite, transform.position, Quaternion.identity);
                Instantiate(ChocWaveGauche, transform.position, Quaternion.identity);
                PhaseInt = 2;
            }
        }

        // Phase 2
        if (PhaseInt == 2 && Timer > DurationPhase2)
        {
            PhaseInt = 3;
        }
        else
        {
            Timer += Time.deltaTime;
        }

        // Phase 3
        if (PhaseInt == 3)
        {
           transform.position += new Vector3(0, 1, 0) * _Speed * Time.deltaTime;
        }

    }
}
