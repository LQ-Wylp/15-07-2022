using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Attaque : MonoBehaviour
{
    public Transform _InitialPos, _EndPos;
    public GameObject _Laser;

    public List<Vector3> _MesPositions;

    public float _MaxX;
    public float _MaxY;

    public float _MiniEcartY;

    public int NbDirectionMin = 3;
    public int NbDirectionMax = 8;
    private int _NbDirection = 1;

    public float SizeLaserMin = 1;
    public float SizeLaserMax = 5;
    private float SizeLaser = 1;

    public float IntervalleSpawnMin;
    public float IntervalleSpawnMax;

    public bool OnAttaqueMode;

    private float Timer = 0;

    void Update()
    {
        if (OnAttaqueMode)
        {
            if (Timer <= 0)
            {
                Timer = Random.Range(IntervalleSpawnMin, IntervalleSpawnMax);
                InitRandom();
                Attaque();
            }
            else
            {
                Timer -= Time.deltaTime;
            }


        }
    }

    void InitRandom()
    {
        _NbDirection = Random.Range(NbDirectionMin, NbDirectionMax +1);
        SizeLaser = Random.Range(SizeLaserMin, SizeLaserMax);
        RandomisationPositionLaser();
    }

    public void Attaque()
    {
        for(int i = 0; i < _NbDirection; i++)
        {
            Vector3 PosA = _MesPositions[i];
            Vector3 PosB = _MesPositions[i+1];

            GameObject LastInstantiate = Instantiate(_Laser, transform.position, Quaternion.identity);
            LastInstantiate.GetComponent<Laser>().Spawn(PosA , PosB , SizeLaser);

        }
    }

    public void RandomisationPositionLaser()
    {
        _MesPositions.Clear();

        _MesPositions.Add(_InitialPos.position);
        for (int i = 0; i < _NbDirection - 1; i++)
        {
            float Tranche = (_MaxX * 2 / (_NbDirection-1) );

            float MinX = Tranche * i - _MaxX;
            float MaxX = Tranche * (i+1) - _MaxX;
            if (MinX > MaxX)
            {
                MinX = MaxX;
            }

            float RandX = Random.Range(MinX,MaxX);
            float RandY = Random.Range(-_MaxY, _MaxY);

            while (Mathf.Abs(RandY - _MesPositions[i].y) < _MiniEcartY)
            {
                RandY = Random.Range(-_MaxY, _MaxY);
            }

            _MesPositions.Add(new Vector3(RandX, RandY, 0));
        }
        _MesPositions.Add(_EndPos.position);
    }
}
