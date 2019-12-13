﻿using UnityEngine;

public class Waypoint : MonoBehaviour
{
    private bool isExplored = false;
    public Waypoint exploredFrom;

    const int gridSize = 10;

    public bool IsExplored
    {
        get => isExplored;
        set
        {
            isExplored = value;
            // SetTopColor(Color.black);
        }
    }
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

    public void SetTopColor(Color color)
    {
        var meshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        meshRenderer.material.color = color;
    }
}