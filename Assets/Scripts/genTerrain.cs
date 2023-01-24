using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genTerrain : MonoBehaviour
{
    public GameObject[] tiles;

    private List<GameObject> gameObjects = new List<GameObject>();

    private void createTile(int x_id, Vector3 x_position)
    {
        GameObject tile = Instantiate(tiles[x_id], Vector3.zero, Quaternion.identity);
        tile.transform.position = x_position;
        tile.transform.eulerAngles = new Vector3(
            tile.transform.eulerAngles.x - 90,
            tile.transform.eulerAngles.y,
            tile.transform.eulerAngles.z
        );
        tile.name = "object" + gameObjects.Count.ToString();
        gameObjects.Add(tile);
    }

    private void changeTileType(GameObject x_tile, int x_id)
    {
        GameObject tile = Instantiate(tiles[x_id], Vector3.zero, Quaternion.identity);
        tile.transform.position = x_tile.transform.position;
        tile.transform.eulerAngles = new Vector3(
            tile.transform.eulerAngles.x - 90,
            tile.transform.eulerAngles.y,
            tile.transform.eulerAngles.z
        );
        tile.name = x_tile.name;
        gameObjects.Add(tile);
        gameObjects.Remove(x_tile);
        Destroy(x_tile);
    }

    void Start()
    {
        createTile(1, new Vector3(0, 0, 0));
        createTile(0, new Vector3(1.7f, 0, 0));
        createTile(0, new Vector3(-1.7f, 0, 0));
        createTile(0, new Vector3(-0.85f, 0, -1.47f));
        createTile(0, new Vector3(0.85f, 0, -1.47f));
        createTile(0, new Vector3(-0.85f, 0, 1.47f));
        createTile(0, new Vector3(0.85f, 0, 1.47f));

        for (int x = 0; x < gameObjects.Count; x++)
        {
            Debug.Log(gameObjects[x]);
        }
    }

    void Update()
    {

    }
}
