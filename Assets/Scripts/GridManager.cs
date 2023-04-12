using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    public GameObject tile;
    public GameObject quadrin;
    public GameObject blocker;

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
        blockTile(3, 3);
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
                tileObjects[i,j] = Instantiate(tile, new Vector3(i - xOffset, j - yOffset, 0), Quaternion.identity, gameObject.transform);
                tiles[i, j] = tileObjects[i, j].GetComponent<Tile>();
            }
        }

        createNewQuadrin(2, 2);
        createNewQuadrin(4, 3);
        createNewQuadrin(2, 3);
    }

    public void blockTile(int x, int y)
    {
        if (tiles[x,y].blocked == false)
        {
            GameObject block = Instantiate(blocker, new Vector3(0, 0, 0), Quaternion.identity, gameObject.transform);
            setPosByGrid(x, y, block);
            tiles[x, y].blocker = block;
        }
        tiles[x, y].blocked = true;
    }

    public void clearTile(int x, int y)
    {
        if (tiles[x, y].blocked) {
            Destroy(tiles[x, y].blocker);
            tiles[x, y].blocked = false;
        }
        if (tiles[x,y].quadrin != null)
        {
            Destroy(tiles[x, y].quadrin);
            quadrinObjects.Remove(tiles[x, y].quadrin);
            quadrins.Remove(tiles[x, y].quadrin.GetComponent<Quadrin>());
            tiles[x, y].quadrin = null;
        }
    }

    public void createNewQuadrin(int x, int y)
    {
        GameObject quad = Instantiate(quadrin, new Vector3(0, 0, 0.01f), Quaternion.identity, gameObject.transform);
        addQuadrin(quad);
        quad.GetComponent<Quadrin>().pos[0] = x;
        quad.GetComponent<Quadrin>().pos[1] = y;

        setPosByGrid(x, y, quad);
        tiles[x, y].quadrin = quad;
    }

    public void moveQuadrins(int x, int y)
    {

        foreach (Quadrin quadrin in quadrins)
        {
            if (quadrin.pos[0] + x >= width || quadrin.pos[0] + x < 0
                || quadrin.pos[1] + y > height || quadrin.pos[1] + y < 0)
            {
                return;
            }

            if (tiles[quadrin.pos[0] + x, quadrin.pos[1] + y].blocked)
            {
                return;
            }
        }

        foreach (Quadrin quadrin in quadrins)
        {
            if (tiles[quadrin.pos[0], quadrin.pos[1]].quadrin == quadrin.gameObject) {
                tiles[quadrin.pos[0], quadrin.pos[1]].quadrin = null;
            }
            quadrin.pos[0] += x;
            quadrin.pos[1] += y;
            tiles[quadrin.pos[0], quadrin.pos[1]].quadrin = quadrin.gameObject;
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
}
