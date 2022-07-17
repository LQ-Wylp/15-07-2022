using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    public float _HealthMax;
    public float _HealthRemaining;

    public float _DurationImmunity;
    private float _ImmunityTime;

    public UnityEvent _DieEvent;

    // Start is called before the first frame update
    void Start()
    {
        _HealthRemaining = _HealthMax;
    }

    void CheckDie()
    {
        if(_HealthRemaining <= 0)
        {
            _DieEvent.Invoke();
        }
    }

    public void DeleteThis()
    {
        Destroy(this.gameObject);
    }

    public void TakeDammageArc(float value)
    {
      _HealthRemaining -= value;
      CheckDie();
    }

    public void TakeDammage(float value)
    {
        if (_ImmunityTime <= 0)
        {
            _HealthRemaining -= value;
            CheckDie();
            _ImmunityTime = _DurationImmunity;
        }
    }

    void Update()
    {
        _ImmunityTime -= Time.deltaTime;
    }
}
