using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Laser_Preshot : MonoBehaviour
{
    public float duration;
    public UnityEvent _EndPreshot;

    // Update is called once per frame
    void Update()
    {
        duration -= Time.deltaTime;
        if(duration <= 0)
        {
            _EndPreshot.Invoke();
        }
    }
}
