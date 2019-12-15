using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] int towerLimit;
    [SerializeField] Transform towerParent;

    Queue<Tower> towers = new Queue<Tower>();

    public void AddTower(Waypoint baseWaypoint)
    {
        if (towers.Count < towerLimit) { InstantiateNewTower(baseWaypoint); }
        else { MoveExistingTower(baseWaypoint); }
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        Tower tower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        tower.transform.parent = towerParent;
        tower.BaseWaypoint = baseWaypoint;
        baseWaypoint.IsPlaceable = false;
        towers.Enqueue(tower);
    }

    private void MoveExistingTower(Waypoint newBaseWaypoint)
    {
        var oldTower = towers.Dequeue();

        oldTower.BaseWaypoint.IsPlaceable = true;
        newBaseWaypoint.IsPlaceable = false;
        oldTower.transform.position = newBaseWaypoint.transform.position;
        oldTower.BaseWaypoint = newBaseWaypoint;

        towers.Enqueue(oldTower);
    }
}
