using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poing_IA : MonoBehaviour
{
    public GameObject _Poing;

    public float IntervalleSpawnMin;
    public float IntervalleSpawnMax;

    public bool OnAttaqueMode;

    private float Timer = 0;

    public Transform PosA;
    public Transform PosB;

    void Update()
    {
        if (OnAttaqueMode)
        {
            if (Timer <= 0)
            {
                Timer = Random.Range(IntervalleSpawnMin, IntervalleSpawnMax);
                Attaque();
            }
            else
            {
                Timer -= Time.deltaTime;
            }
        }
    }

    public void Attaque()
    {
        int i = Random.Range(0, 100);
        if(i < 50)
        {
            Instantiate(_Poing, PosA.position, Quaternion.identity);
        }
        else
        {
            Instantiate(_Poing, PosB.position, Quaternion.identity);
        }
    }
}
