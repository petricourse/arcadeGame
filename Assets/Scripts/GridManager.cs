using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    public GameObject tile;
    public GameObject quadrin;

    public InputManager inputManager;

    public int width;
    public int height;

    public GameObject[,] tileObjects;
    public Tile[,] tiles;

    List<GameObject> quadrinObjects = new List<GameObject>();
    List<Quadrin> quadrins = new List<Quadrin>();

    // Start is called before the first frame update
    void Start()
    {
        initGrid(8, 8);
    }

    public void initGrid(int width, int height)
    {
        tileObjects = new GameObject[width,height];
        tiles = new Tile[width, height];
        this.width = width;
        this.height = height;
        float xOffset = width / 2f;
        float yOffset = height / 2f;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Instantiate(tile, new Vector3(i - xOffset, j - yOffset, 0), Quaternion.identity, gameObject.transform);
            }
        }

        createNewQuadrin(2, 2);
        createNewQuadrin(4, 3);
        createNewQuadrin(2, 3);
    }

    public void createNewQuadrin(int x, int y)
    {
        GameObject quad = Instantiate(quadrin, new Vector3(0, 0, 0.01f), Quaternion.identity, gameObject.transform);
        addQuadrin(quad);
        quad.GetComponent<Quadrin>().pos[0] = x;
        quad.GetComponent<Quadrin>().pos[1] = y;

        setPosByGrid(x, y, quad);
    }

    public void moveQuadrins(int x, int y)
    {
        int highestX = 0;
        int lowestX = width - 1;
        int highestY = 0;
        int lowestY = height - 1;

        foreach (Quadrin quadrin in quadrins)
        {
            if (quadrin.pos[0] > highestX)
            {
                highestX = quadrin.pos[0];
            }
            if (quadrin.pos[0]  < lowestX)
            {
                lowestX = quadrin.pos[0];
            }
            if (quadrin.pos[1] > highestY)
            {
                highestY = quadrin.pos[1];
            }
            if (quadrin.pos[1]  < lowestY)
            {
                lowestY = quadrin.pos[1];
            }
        }

        //Debug.Log("HX: " + highestX + ", " + highestY);
        //Debug.Log("HY: " + highestY + ", " + lowestY);

        if (highestX + x >= width || lowestX + x < 0 || highestY + y >= height || lowestY + y < 0)
        {
            Debug.Log("Quadrin move failure!");
            return;
        }

        foreach (Quadrin quadrin in quadrins)
        {
            quadrin.pos[0] += x;
            quadrin.pos[1] += y;
            setPosByGrid( quadrin.pos[0], quadrin.pos[1], quadrin.gameObject);
        }
    }

    private void addQuadrin(GameObject quad)
    {
        quadrinObjects.Add(quad);
        quadrins.Add(quad.GetComponent<Quadrin>());
    }

    private void setPosByGrid(int gridX, int gridY, GameObject obj)
    {
        obj.transform.position = new Vector3(gridX - width / 2f, gridY - height / 2f, obj.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
