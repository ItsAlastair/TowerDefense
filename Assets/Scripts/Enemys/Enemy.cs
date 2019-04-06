using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour              //Main Class for all Enemys
{
    private float maxHealth;
    public float health;
    public int moneyForKill;
    private NavMeshAgent agent;
    private float normalSpeed;
    public Transform destination;
    private float distanceToEnd;

    [Header("Lebensbalken")]
    public Canvas healthbar;

    [Header("Blut")]
    public GameObject blutspritzer;

    [Header("De/Buffs")]
    public bool freeze;

    virtual protected void Start()
    {
        maxHealth = health;
        agent = GetComponent<NavMeshAgent>();
        normalSpeed = agent.speed;
    }

    virtual protected void Update()
    {
        SetDestination();
        CheckIfGoalReached();
        

        //healthbar.transform.LookAt(Camera.main.transform);
        //healthbar.GetComponentInChildren<Image>().fillAmount = health / maxHealth;

        if (!freeze) agent.speed = normalSpeed;
        else agent.speed = normalSpeed / 2;

    }

    protected void SetDestination()
    {
        NavMeshPath path = new NavMeshPath();
        agent.CalculatePath(destination.position, path);
        if (path.status == NavMeshPathStatus.PathPartial)
        {
            Debug.LogError("Kein Endziel erreichbar");
        }
        else
        {
            agent.SetDestination(destination.position);
        }
    }

    protected void CheckIfGoalReached()
    {
        distanceToEnd = Vector3.Distance(transform.position, destination.position);
        if (distanceToEnd <= 1f)
        {
            GameManager.currentLifes -= 1;
            Destroy(gameObject);
        }
    }

    public void GetDamage(float _damage)
    {
        health -= _damage;

        if (health <= 0)
        {
            //Instantiate(blutspritzer, transform.position + Vector3.up, Quaternion.identity);
            GameManager.currentCoins += moneyForKill;
            Destroy(gameObject);
        }
    }

}
