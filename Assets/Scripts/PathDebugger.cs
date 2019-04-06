using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(LineRenderer))]
public class PathDebugger : MonoBehaviour
{
    [SerializeField] private NavMeshAgent enemyPath = null;
    private LineRenderer lineRenderer;
    [SerializeField] private Transform goal = null;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        InvokeRepeating("CheckPath", 0, 1);
    }

    private void Update()
    {
        if (enemyPath.path.status == NavMeshPathStatus.PathPartial)
        {
            GameManager.readyForWave = false;
            Debug.LogError("Kein Endziel erreichbar");
        }
        else
        {
            GameManager.readyForWave = true;
        }

        if (enemyPath.hasPath)
        {
            lineRenderer.positionCount = enemyPath.path.corners.Length;
            lineRenderer.SetPositions(enemyPath.path.corners);
            lineRenderer.enabled = true;
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }

    void CheckPath()
    {
        enemyPath.destination = goal.position;
    }
}
