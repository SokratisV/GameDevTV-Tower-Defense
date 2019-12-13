using TMPro;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        Vector2 pos = waypoint.GetGridPos();
        int gridSize = waypoint.GetGridSize();
        transform.position = new Vector3(pos.x * gridSize, 0, pos.y * gridSize);
    }

    private void UpdateLabel()
    {
        Vector2 pos = waypoint.GetGridPos();
        TextMeshProUGUI worldSpaceText = GetComponentInChildren<TextMeshProUGUI>();

        string labelText = $"{pos.x}.{pos.y}";
        worldSpaceText.text = labelText;
        name = labelText;
    }
}
