using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint exploredFrom;

    private bool isExplored = false, isPlaceable = true;
    const int gridSize = 10;

    public bool IsExplored { get => isExplored; set => isExplored = value; }

    public bool IsPlaceable { get => isPlaceable; set => isPlaceable = value; }

    public int GetGridSize()
    {
        return gridSize;
    }
    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlaceable)
            {
                FindObjectOfType<TowerFactory>().AddTower(this);
            }
        }
    }
}