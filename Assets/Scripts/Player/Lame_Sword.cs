using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lame_Sword : MonoBehaviour
{
    public float _Dammage = 1;

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Ennemy")
        {
            other.gameObject.GetComponent<HealthSystem>().TakeDammage(_Dammage);
        }
    }
}
