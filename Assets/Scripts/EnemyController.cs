using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class EnemyController : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] waypoints;
    int waypointIndex;
    Vector3 target;
    public TextMeshProUGUI enemyLevelText;

    public PlayerLevel playerLevel;
    [SerializeField] GameObject player;

    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private Animator animator;
    [SerializeField] int enemyLevel;
    // [SerializeField] private FieldOfView fieldOfView;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
        enemyLevelText.text = "lv. " + enemyLevel.ToString();
        enemyLevelText.color = new Color(1, 0, 0, 1);
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, target) < 1)
        {
            IterateWaypointIndex();
            UpdateDestination();
        }
        
        //fieldOfView.SetOrigin(transform.position);
        // fieldOfView.SetAimDirection(GetAimDir());
    }

    void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }

    void IterateWaypointIndex()
    {
        waypointIndex++;
        if(waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }

}
