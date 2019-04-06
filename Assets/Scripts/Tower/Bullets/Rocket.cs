using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Bullet
{
    public GameObject exploEffect;
    public AudioSource exploSound;

    protected override void HitTarget()
    {
        LayerMask enemyLayer = LayerMask.GetMask("Enemy");
        exploSound.Play();
        Instantiate(exploEffect, transform.position, Quaternion.identity);
        

        Collider[] enemys = Physics.OverlapSphere(transform.position, exploRange, enemyLayer);

        foreach (Collider enemy in enemys)
        {
            enemy.GetComponent<Enemy>().GetDamage(damage);
        }
        GetComponentInChildren<MeshRenderer>().enabled = false;
        Destroy(gameObject,1f);
        enabled = false;
    }
}
