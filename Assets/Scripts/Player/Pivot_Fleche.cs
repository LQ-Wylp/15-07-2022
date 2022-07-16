using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot_Fleche : MonoBehaviour
{
    public float _Speed = 1;
    public Vector3 _Direction;

    public GameObject PivotExt;
    private float SpeedPivotExt;
    public float SpeedMaxPivotExt;

    public GameObject PivotInt;
    private float SpeedPivotInt;
    public float SpeedMaxPivotInt;

    public GameObject BulletExt;
    public GameObject BulletInt;

    public BulletArc _BaExtGauche;
    public BulletArc _BaExtDroite;
    public BulletArc _BaIntGauche;
    public BulletArc _BaIntDroite;
    public BulletArc _BaCentre;

    public float SpeedBulletMax;
    public float RotateSpeedMax;

    public void Spawn(Vector3 directionTarg)
    {
        _Direction = directionTarg;
        float angle = Mathf.Atan2(_Direction.y, _Direction.x) * Mathf.Rad2Deg;
        // rotate to angle
        Quaternion rotation = new Quaternion();
        rotation.eulerAngles = new Vector3(0, 0, angle - 90);
        transform.rotation = rotation;
    }

    void Update()
    {
        transform.position += _Direction * _Speed * Time.deltaTime;

        PivotExt.transform.Rotate(0, 0, SpeedPivotExt * Time.deltaTime);
        PivotInt.transform.Rotate(0, 0, SpeedPivotInt * Time.deltaTime);
    }

    public void RandomiseBullet()
    {
        // Aléatoire Nouveau
        int i = Random.Range(0, 100);
        if(i < 25)
        {
            SpeedPivotExt = Random.Range(0, SpeedMaxPivotExt);
        }

        // Aléatoire Nouveau
        i = Random.Range(0, 100);
        if (i < 25)
        {
            SpeedPivotInt = Random.Range(0, SpeedMaxPivotInt);
        }

        // Aléatoire Nouveau
        i = Random.Range(0, 100);
        if (i < 25)
        {
            BulletExt.SetActive(true);
        }
        else
        {
            BulletExt.SetActive(false);
        }

        // Aléatoire Nouveau
        i = Random.Range(0, 100);
        if (i < 25)
        {
            BulletInt.SetActive(true);
        }
        else
        {
            BulletInt.SetActive(false);
        }

        // Aléatoire Nouveau
        i = Random.Range(0, 100);
        if (i < 25)
        {
            float Tmp = Random.Range(0, SpeedBulletMax);
            _BaExtGauche.Speed = Tmp;
            _BaExtDroite.Speed = Tmp;


            Tmp = Random.Range(0, RotateSpeedMax);
            _BaExtGauche.SpeedRotate = Tmp;
            _BaExtDroite.SpeedRotate = Tmp;
        }

        // Aléatoire Nouveau
        i = Random.Range(0, 100);
        if (i < 25)
        {
            float Tmp = Random.Range(0, SpeedBulletMax);
            _BaIntGauche.Speed = Tmp;
            _BaIntDroite.Speed = Tmp;


            Tmp = Random.Range(0, RotateSpeedMax);
            _BaIntGauche.SpeedRotate = Tmp;
            _BaIntDroite.SpeedRotate = Tmp;
        }

    }
}
