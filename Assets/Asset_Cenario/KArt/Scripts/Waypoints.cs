using UnityEngine;
/// <summary>
/// este script vaiatachado ao kart para brotar waypoints no mapa
/// ele brota a cada 5 metros de distancia exatamente acima do solo
/// 
/// </summary>
public class Waypoints : MonoBehaviour
{
    public GameObject waypointPrefab;
    public float distance = 5;
    public float height = 1.0f;

    //variavel para q ele brote atraz do kart
    public Vector3 offset = new Vector3(0, 0, -5);
    public GameObject waypoint;
    public GameObject waypointContainer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //cria o primeiro waypoint
        waypoint = Instantiate(waypointPrefab, transform.position + offset, Quaternion.identity);
        waypoint.transform.parent = waypointContainer.transform;
        waypoint.name = "Waypoint" + waypointContainer.transform.childCount;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 100))
        {
            pos = new Vector3(transform.position.x, hit.point.y + height, transform.position.z) + offset;
        }

        if (Vector3.Distance(pos, waypoint.transform.position) > distance)
        {
            Debug.Log("Brotando waypoint");
            GameObject newwaypoint = Instantiate(waypointPrefab, pos + offset, Quaternion.identity);
            newwaypoint.transform.parent = waypointContainer.transform;
            waypointPrefab = newwaypoint;
            //renomeia o waypoint
            newwaypoint.name = "Waypoint" + waypointContainer.transform.childCount;
            waypoint = newwaypoint;

        }


    }
}
