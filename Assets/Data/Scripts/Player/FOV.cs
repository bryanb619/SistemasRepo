using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class FOV : MonoBehaviour
{

    private enum GameState { MUSTDIE, ULIVE}
    private GameState state; 
    private bool canSeePlayer;
    public bool CanSeeTarget => canSeePlayer;

    [Header("Target for debug only")]
    [SerializeField]private Transform target; 
    public Transform Target => target;

    [Range(10, 150)]
    public float radius;
    //public float Radius => radius;
    [Range(50, 360)]
    public float angle;
    //public float Angle => angle;


    public LayerMask targetMask;
    public LayerMask obstructionMask;
    [SerializeField] private Transform fov;
    public Transform PFOV => fov; // Enemy Editor FOV

    private void Start()
    {
        state= GameState.ULIVE;
    }


    private void Update()
    {
        StartCoroutine(FOVRoutine());

        ConditionCheck();
    }

    #region Field of view Routine
    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }


    private void ConditionCheck()
    {
        if(state == GameState.MUSTDIE)
        {
            SceneManager.LoadScene("_EndGame"); 
        }


    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(fov.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - fov.position).normalized;

            if (Vector3.Angle(fov.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(fov.position, target.position);

                if (!Physics.Raycast(fov.position, directionToTarget, distanceToTarget, obstructionMask)) {

                    canSeePlayer = true;
                    state= GameState.MUSTDIE;    

                }
                    
                else
                    canSeePlayer = false;
            }
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer)
            canSeePlayer = false;
    }

    #endregion
}
