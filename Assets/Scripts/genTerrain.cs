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
        GameObject tile = Instantiate(tiles[x_id], x_position, Quaternion.identity);
        tile.transform.eulerAngles = new Vector3(
            tile.transform.eulerAngles.x - 90,
            tile.transform.eulerAngles.y,
            tile.transform.eulerAngles.z
        );
        tile.name = "object" + gameObjects.Count.ToString();
        tile.GetComponent<TileHandler>().TileId = x_id;
        gameObjects.Add(tile);
    }

    private void changeTileType(GameObject x_tile)
    {
        int x_id = x_tile.GetComponent<TileHandler>().TileId;
        GameObject tile = Instantiate(tiles[x_id], x_tile.transform.position, Quaternion.identity);
        tile.transform.eulerAngles = new Vector3(
            tile.transform.eulerAngles.x - 90,
            tile.transform.eulerAngles.y,
            tile.transform.eulerAngles.z
        );
        tile.name = x_tile.name;
        tile.GetComponent<TileHandler>().TileId = x_id;
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
    }

    void Update()
    {
        for (int x = 0; x < gameObjects.Count; x++)
        {
            changeTileType(gameObjects[x]);
        }
    }
}
