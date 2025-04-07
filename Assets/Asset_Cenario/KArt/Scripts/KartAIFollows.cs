using UnityEngine;
using KartGame.KartSystems;
/// <summary>
/// esta classe segue o caminho de waypoints
/// </summary>
public class KartAIFollows : BaseInput
{
    Transform[] waypoints;
    public GameObject wayfather;

    public bool isFollowing = true;

    public int distanceToWaypoint = 10;


    int index = 0;
    Transform target;
    int turn = 0;

    private void Start()
    {
        waypoints = wayfather.transform.GetComponentsInChildren<Transform>();
        target = waypoints[0];
    }


    public override InputData GenerateInput()
    {

        target = waypoints[index];

        //se a distancia entre o kart e o waypoint for menor , muda o waypoint
        if (Vector3.Distance(transform.position, target.position) < distanceToWaypoint)
        {
            index++;
            if (index >= waypoints.Length)
            {
                index = 0;
            }
        }

        turn = (int)(Vector3.Dot(transform.right, (target.position - transform.position).normalized) * 10);

        if (!isFollowing)
        {
            return new InputData
            {
                Accelerate = false,
                Brake = false,
                TurnInput = 0,
            };
        }
        else
        {
            return new InputData
            {
                Accelerate = true,
                Brake = false,
                TurnInput = turn,
            };
        }
    }
}
