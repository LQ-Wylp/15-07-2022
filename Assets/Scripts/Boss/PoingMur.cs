using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoingMur : MonoBehaviour
{
    public GameObject _PoingMur;

    public float ScalerMin = 1;
    public float ScalerMax = 5;
    private float Scale;

    public float _MaxX;
    public float _MaxY;

    public float IntervalleSpawnMin;
    public float IntervalleSpawnMax;

    public bool OnAttaqueMode;

    private float Timer = 0;

    public void Attaque()
    {
        float RandX = Random.Range(-_MaxX, _MaxX);
        float RandY = Random.Range(-_MaxY, _MaxY);
        Scale = Random.Range(ScalerMin, ScalerMax);

        GameObject LastInstantiate = Instantiate(_PoingMur, new Vector3(RandX, RandY, 0), Quaternion.identity);

        Vector3 NewScale = new Vector3(LastInstantiate.transform.localScale.x * Scale, LastInstantiate.transform.localScale.y * Scale, transform.localScale.z);
        LastInstantiate.transform.localScale = NewScale;
        
    }

    void Update()
    {
        if (OnAttaqueMode)
        {
            if(Timer <= 0)
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
}
