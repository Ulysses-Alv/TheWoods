using UnityEngine;
using PathCreation;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(PathCreator))]
public class PathGenerator : MonoBehaviour
{
    public List<Transform> waypoints;

    [SerializeField] private WayPointGenerator wayPointGenerator;

    [Range(4f, 10f)]
    [SerializeField] private int waypointsAmount;


    [ContextMenu("Generar Camino")]
    void GeneratePath()
    {
        waypoints.ForEach((waypoint) => DestroyImmediate(waypoint.gameObject));
        waypoints.Clear();
        waypoints = wayPointGenerator.GenerateWayPoints(waypointsAmount);

        BezierPath bezierPath = new BezierPath(waypoints, false, PathSpace.xz);
        GetComponent<PathCreator>().bezierPath = bezierPath;

    }
}