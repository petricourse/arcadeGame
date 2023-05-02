using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public bool gameActive = true;
    public GridManager gridManager;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            gridManager.moveQuadrins(0, 1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            gridManager.moveQuadrins(0, -1);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gridManager.moveQuadrins(-1, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gridManager.moveQuadrins(1, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gridManager.clearTile(3, 3);
        }
    }
}
