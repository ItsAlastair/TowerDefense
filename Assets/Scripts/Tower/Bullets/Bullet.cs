using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed;
    public float damage;
    public float exploRange;


    public void Seek(Transform _target)
    {
        target = _target;
    }


    private void Update()
    {
        if (target == null) Destroy(gameObject);
        transform.LookAt(target);
        Move();
    }

    protected void Move()
    {
        if (target == null) return;
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    virtual protected void HitTarget()
    {
        target.GetComponent<Enemy>().GetDamage(damage);
        Destroy(gameObject);
        return;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, exploRange);
    }
}
