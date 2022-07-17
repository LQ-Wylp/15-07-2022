using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaguePoussier : MonoBehaviour
{
    public float _Speed;
    public Collider2D _Collider;

    void Update()
    {
        transform.position += new Vector3(1, 0, 0) * Time.deltaTime * _Speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<HealthSystem>().TakeDammage(1);
            Destroy(_Collider);
        }

        if (other.gameObject.tag == "Mur")
        {
            Destroy(gameObject);
        }
    }
}
