using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletArc : MonoBehaviour
{
    public float _Dammage = 1;
    public GameObject Root;

    public float Speed;
    public float SpeedRotate;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }

        if(other.gameObject.tag == "Ennemy")
        {
            other.gameObject.GetComponent<HealthSystem>().TakeDammage(_Dammage);
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        transform.position += transform.up * Speed * Time.deltaTime;
        transform.Rotate(0, 0, SpeedRotate * Time.deltaTime);
    }
}
