using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public void Spawn(Vector3 PosA, Vector3 PosB, float SizeLaser)
    {
        transform.position = (PosB + PosA) / 2;
        Vector3 NewScale = new Vector3(transform.localScale.x * SizeLaser, Vector3.Distance(PosB, PosA), transform.localScale.z);
        transform.localScale = NewScale;

        // LookAt 2D
        Vector3 target = PosB;
        // get the angle
        Vector3 _DirectionLookAt = (target - transform.position).normalized;
        float angle = Mathf.Atan2(_DirectionLookAt.y, _DirectionLookAt.x) * Mathf.Rad2Deg;
        // rotate to angle
        Quaternion rotation = new Quaternion();
        rotation.eulerAngles = new Vector3(0, 0, angle - 90);
        transform.rotation = rotation;
    }
}
