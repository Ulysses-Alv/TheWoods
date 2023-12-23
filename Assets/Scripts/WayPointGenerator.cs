using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class WayPointGenerator : MonoBehaviour
{
    [SerializeField] private CreateMap map;
    [SerializeField] private Transform waypointParent;
    private List<GameObject> floors => map._floorsMap;


    public List<Transform> GenerateWayPoints(int waypointsAmount)
    {
        Vector3 first = floors.First().transform.position; //pos x,z = min
        Vector3 last = floors.Last().transform.position; //pos x,z = max

        List<Transform> result = new List<Transform>();

        for (int i = 0; i < waypointsAmount; i++)
        {
            string name = "waypoint:" + i;

            GameObject waypoint = new GameObject(name);
            waypoint.transform.parent = waypointParent;

            waypoint.transform.position = GetWaypointPosition(i, waypointsAmount, first, last);

            result.Add(waypoint.transform);
        }

        return result;
    }

    private Vector3 GetWaypointPosition(int waypointNumber, int waypointsAmount, Vector3 first, Vector3 last)
    {
        float lenghtX = Mathf.Abs(first.x - last.x);
        float lenghtZ = Mathf.Abs(first.z - last.z);
        float centerX = lenghtX / 2;

        float fractionZ = (lenghtZ / (waypointsAmount - 1)) * waypointNumber;

        float positionZ = Random.Range(0.8f * fractionZ, 1.2f * fractionZ);
        float positionX = Random.Range(0.25f * centerX, 1.75f * centerX);

        if (waypointNumber == 0)
        {
            positionZ = first.z - 5;
            positionX = centerX;
        }
        if (waypointNumber == waypointsAmount - 1)
        {
            positionZ = last.z + 5;
        }

        return new Vector3(positionX, 0f, positionZ);
    }
}