using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Bullet
{
    protected override void HitTarget()
    {
        LayerMask enemyLayer = LayerMask.GetMask("Enemy");
        //Instantiate(exploeffect, transform.position + Vector3.up / 2, Quaternion.identity);

        Collider[] enemys = Physics.OverlapSphere(transform.position, exploRange, enemyLayer);

        foreach (Collider enemy in enemys)
        {
            enemy.GetComponent<Enemy>().GetDamage(damage);
        }
        Destroy(gameObject);
    }
}
