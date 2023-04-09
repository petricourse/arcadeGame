using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    public GameObject tile;
    public GameObject[,] tileObjects;
    public Tile[,] tiles;

    // Start is called before the first frame update
    void Start()
    {
        initGrid(5, 5);
    }

    public void initGrid(int width, int height)
    {
        tileObjects = new GameObject[width,height];
        tiles = new Tile[width, height];

        float xOffset = width / 2f;
        float yOffset = height / 2f;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Instantiate(tile, new Vector3(i - xOffset, j - yOffset, 0), Quaternion.identity, gameObject.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
