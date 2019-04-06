
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    #region Attributes
    [Header("Stats")]
    public int level = 1;
    float damageSTD = 0;
    public float damage = 1;
    float rangeSTD = 0;
    public float range = 10;
    float exploRangeSTD = 0;
    public float exploRange = 2;
    float fireRateSTD = 0;
    public float fireRate = 1f;
    float currentSupportRate = 0;
    public bool supported = false;

    [Header("Costs")]
    public int upgradeCost;
    public int towerCost;

    [Header("Feuern")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Transform firePoint2;
    protected float fireCountdown;
    public LineRenderer laser1;
    public LineRenderer laser2;

    [Header("Rotation")]
    public Transform rotationPart;
    public float turnSpeed = 10;

    [Header("RangeStuff")]
    public GameObject towerRange;
    protected SphereCollider sCollider;
    public List<Enemy> enemyInRange = new List<Enemy>();

    [Header("Enemy")]
    protected Enemy target = null;

    [Header("AttackFocus")]
    public AttackFocus attackFocus = AttackFocus.First;
    public enum AttackFocus
    {
        First,
        Last,
        Random
    }
    #endregion

    virtual protected void Start()
    {
        sCollider = GetComponent<SphereCollider>();
        InvokeRepeating("GetTarget",0, 0.25f);

    }

    

    virtual protected void Update()
    {
        SetRangeSize();

        if (target == null) return;
        RotateToEnemy();
        ShootCooldown();

    }

    public void SupportTower(float supportRate)
    {
        if (supportRate > currentSupportRate)
        {
            currentSupportRate = supportRate;
            SupportTowerStop();
            return;
        }

        if (!supported)
        {
            damageSTD = damage;
            rangeSTD = range;
            fireRateSTD = fireRate;
            exploRangeSTD = exploRange;
            damage *= currentSupportRate;
            range *= currentSupportRate;
            fireRate *= currentSupportRate;
            exploRange *= currentSupportRate;
            supported = true;
        }
    }

    public void SupportTowerStop()
    {
        if (supported)
        {
            damage = damageSTD;
            range = rangeSTD;
            fireRate = fireRateSTD;
            exploRange = exploRangeSTD;
            supported = false;
        }
    }

    protected void SetRangeSize()
    {
        towerRange.transform.localScale = Vector3.one * range * 2;
        sCollider.radius = range;
    }

    protected void RotateToEnemy()
    {
        Vector3 dir = target.transform.position - rotationPart.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(rotationPart.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        rotationPart.rotation = Quaternion.Euler(rotation);
    }

    protected void ShootCooldown()
    {
        if (fireCountdown <= 0f)
        {
            StartCoroutine(Shoot());
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    virtual protected IEnumerator Shoot()
    {
        GameObject BulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = BulletGO.GetComponent<Bullet>();
        bullet.Seek(target.transform);
        bullet.damage = damage;
        bullet.exploRange = exploRange;
        //mf_light.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        //mf_light.SetActive(false);
        
    }

    protected void GetTarget()
    {
        for (int i = 0; i < enemyInRange.Count; i++)
        {
            Enemy tempTarget = enemyInRange[i];
            if (tempTarget == null)
                enemyInRange.Remove(tempTarget);
        }

        if (enemyInRange.Count > 0)
        {
            switch (attackFocus)
            {
                case AttackFocus.First:
                    target = enemyInRange[0];
                    break;
                case AttackFocus.Last:
                    target = enemyInRange[enemyInRange.Count - 1];
                    break;
                case AttackFocus.Random:
                    target = enemyInRange[Random.Range(0, enemyInRange.Count)];
                    break;
            }

        }
        else target = null;
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyInRange.Add(other.GetComponent<Enemy>());
        }
    }

    protected void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyInRange.Remove(other.GetComponent<Enemy>());
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
