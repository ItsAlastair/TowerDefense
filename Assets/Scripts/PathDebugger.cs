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
        enemyPath.destination = goal.position;
    }

    private void Update()
    {
        CheckPath();

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

    public bool CheckPath()
    {

        if (enemyPath.path.status != NavMeshPathStatus.PathComplete)
        {
            GameManager.readyForWave = false;
            PanelHolder.panelHolder.StopAllCoroutines();
            PanelHolder.panelHolder.StartCoroutine("WarningText", "YOU BLOCKED THE ENEMY PATH! \n BREAK 1 WALL FOR FREE, IDIOT!");
            return false;
        }
        else
        {
            GameManager.readyForWave = true;
            return true;
        }

        
    }
}
