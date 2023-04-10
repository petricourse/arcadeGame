using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject grid;
    public InputManager inputManager;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gridObj = Instantiate(grid);
        GridManager gridMono = gridObj.GetComponent<GridManager>();
        gridMono.inputManager = inputManager;
        inputManager.gridManager = gridMono; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
