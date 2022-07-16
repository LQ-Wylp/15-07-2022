using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PoingMur_Dommageable : MonoBehaviour
{
    public GameObject Root;
    public float duration;
    public UnityEvent _EndPreshot;
    public Collider2D _Collider;

    // Update is called once per frame
    void Update()
    {
        duration -= Time.deltaTime;
        if (duration <= 0)
        {
            _EndPreshot.Invoke();
        }
    }

    public void DestroyRoot()
    {
        Destroy(Root);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<HealthSystem>().TakeDammage(1);
            Destroy(_Collider);
        }
    }
}
