using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Tower : Tower
{
    

    override protected void Start()
    {
        
        base.Start();
        laser1 = firePoint.GetComponent<LineRenderer>();
        laser2 = firePoint2.GetComponent<LineRenderer>();
        laser1.enabled = false;
        laser2.enabled = false;
    }

    override protected void Update()
    {
        SetRangeSize();
        LaserBeam();
        if (target == null) return;
        RotateToEnemy();
    }

    void LaserBeam()
    {
        if(target == null)
        {
            laser1.enabled = false;
            laser2.enabled = false;
            return;
        }

        laser1.SetPosition(0, firePoint.position);
        laser1.SetPosition(1, target.transform.position);
        laser2.SetPosition(0, firePoint2.position);
        laser2.SetPosition(1, target.transform.position);
        laser1.enabled = true;
        laser2.enabled = true;

        target.GetDamage(damage / 2);
    }
}
