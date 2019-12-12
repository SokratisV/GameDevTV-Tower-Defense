using TMPro;
using UnityEngine;

[ExecuteInEditMode]
public class CubeEditor : MonoBehaviour
{
    [SerializeField] [Range(1f, 20f)] float gridSize = 10f;
    TextMeshProUGUI worldSpaceText;
    Vector3 snapPos;

    private void Start()
    {
        worldSpaceText = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        transform.position = new Vector3(snapPos.x, 0, snapPos.z);
        worldSpaceText.text = $"{snapPos.x / gridSize}.{snapPos.z / gridSize}";
    }
}
