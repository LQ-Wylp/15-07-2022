using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Move _move;
    private float _Power;
    public float _PowerMin;
    public float _PowerMax;

    public List<GameObject> MesEpees; // 0 = EpeePetit // 1 = EpeeMoyen // 2 = EpeeGrand

    public void RandomiseSword(int index)
    {
        _Power = Random.Range(_PowerMin, _PowerMax);

        for(int i = 0; i < MesEpees.Count; i++)
        {
            MesEpees[i].SetActive(false);
        }

        MesEpees[index].SetActive(true);
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
            _move.Impulse(new Vector2(_move._DirectionMouse.x, _move._DirectionMouse.y), _Power);
            _move._CanShot = false;
        }
    }
}
