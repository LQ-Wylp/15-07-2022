using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arc : MonoBehaviour
{
    public Move _move;

    public float PowerMin;
    public float PowerMax;

    private float _Power;

    public GameObject _Bullet;

    public Transform _WhereSpawnBullet;

    public Pivot_Fleche _Pivot_Fleche;

    public void RandomiseArc()
    {
        _Power = Random.Range(PowerMin, PowerMax);
        _Pivot_Fleche.RandomiseBullet();
    }

    void OnClick()
    {
        if (_move._OnJump)
        {
            Shot();
        }
    }

    void Shot()
    {
        if (_move._CanShot)
        {
            _move.Impulse(-new Vector2 (_move._DirectionMouse.x, _move._DirectionMouse.y), _Power);
            GameObject LastInstantiate = Instantiate(_Bullet, _WhereSpawnBullet.position, Quaternion.identity);
            LastInstantiate.SetActive(true);
            LastInstantiate.GetComponent<Pivot_Fleche>().Spawn(_move._DirectionMouse);
            _move._CanShot = false;
        }
    }
}
