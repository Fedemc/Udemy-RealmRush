﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    Vector2Int gridPos;
    const int gridSize = 10;
    [SerializeField] Color exploredColor=Color.blue;

    //public esta bien pq es una clase con datos solamente
    public bool isExplored=false;
    public Waypoint exploredFrom;
    public bool isPlaceable = true;



    void Update()
    {
        if(isExplored)
        {
            //SetTopColor(exploredColor);
        }
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
            );
    }

    public int GetGridSize()
    {
        return gridSize;
    }

    void OnMouseOver()
    {
        //detect mouse click
        if(Input.GetMouseButtonUp(0))
        {
            if(isPlaceable)
            {
                FindObjectOfType<TowerFactory>().AddTower(this);
            }
            else
            {
                Debug.Log("Can't build at " + gameObject.name);
            }
        }
    }
}
