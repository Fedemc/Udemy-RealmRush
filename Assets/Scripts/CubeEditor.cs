using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{
    [SerializeField][Tooltip("Size of the grid")] [Range(1,10)] int gridSize=10;
    TextMesh textMesh;

    private void Start()
    {
        textMesh = GetComponentInChildren<TextMesh>();
    }

    void Update()
    {
        Vector3 snapPosition;
        snapPosition.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPosition.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        transform.position = new Vector3(snapPosition.x, 0f, snapPosition.z);

        textMesh.text = snapPosition.x / gridSize + "," + snapPosition.z / gridSize;
    }
}
