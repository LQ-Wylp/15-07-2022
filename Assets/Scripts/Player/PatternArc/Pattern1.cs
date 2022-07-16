using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern1 : MonoBehaviour
{
    public BulletArc _BaDroite;
    public BulletArc _BaGauche;
    public BulletArc _BaCentre;

    public float SpeedMin;
    public float SpeedMax;   
    
    public float SpeedRotateMin;
    public float SpeedRotateMax;

    private float SpeedCote;
    private float SpeedCentre;
    private float SpeedRotate;

    public void RandomisePattern()
    {
        SpeedCote = Random.Range(SpeedMin, SpeedMax);
        SpeedCentre = Random.Range(SpeedMin, SpeedMax);
        SpeedRotate = Random.Range(SpeedRotateMin, SpeedRotateMax);

        _BaDroite.Speed = SpeedCote;
        _BaGauche.Speed = SpeedCote;
        _BaCentre.Speed = SpeedCentre;

        _BaDroite.SpeedRotate = SpeedRotate;
        _BaGauche.SpeedRotate = -SpeedRotate;
    }
}
