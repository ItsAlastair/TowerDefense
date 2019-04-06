using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Support_Tower : Tower
{

    override protected void Start()
    {
        sCollider = GetComponent<SphereCollider>();
    }

    override protected void Update()
    {
        SetRangeSize();
        SupportNearTower();
    }

    void SupportNearTower()
    {
        Collider[] towerInRange = Physics.OverlapSphere(transform.position, range);

        foreach (Collider c in towerInRange)
        {
            if (c.CompareTag("Tower"))
            {
                Tower t = c.GetComponent<Tower>();
                t.SupportTower(damage);
            }
        }
    }

    private void OnDisable()
    {
        Collider[] towerInRange = Physics.OverlapSphere(transform.position, range);

        foreach (Collider c in towerInRange)
        {
            if (c.CompareTag("Tower"))
            {
                Tower t = c.GetComponent<Tower>();
                t.SupportTowerStop();
            }
        }
    }
}
