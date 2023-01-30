using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHandler : MonoBehaviour
{
    public int TileId = 0;

    void OnMouseOver()
    {
        TileId = 1;
    }
}
