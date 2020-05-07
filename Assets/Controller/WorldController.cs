using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    World _world;

    [SerializeField]
    private Sprite floorFilledSprite;


    void Start()
    {
        _world = new World();

        // Create a GameObject for each tile
        for (int x = 0; x < _world.Width; x++)
        {
            for (int y = 0; y < _world.Height; y++)
            {
                Tile _tileWorld = _world.GetTileAt(x, y);
                GameObject _tileGameObject = new GameObject();
                _tileGameObject.name = "Tile_" + x + "_" + y;
                _tileGameObject.transform.position = new Vector3(_tileWorld.XPosition, _tileWorld.YPosition, 0);
                _tileGameObject.transform.SetParent(this.transform);
                _tileGameObject.AddComponent<SpriteRenderer>();

                // we set the Tile object's '_tileTypeChangedCallback' Action to this method
                _tileWorld.RegisterTileTypeChangeCallback((tile) => { OnTileTypeChanged(tile, _tileGameObject); });
            }
        }

        _world.RandomizeTiles();
    }

    private void Update()
    {
        
    }


    void OnTileTypeChanged(Tile tileWorld, GameObject tileGameObject)
    {
        if (tileWorld.Type == Tile.TileType.Floor)
        {
            tileGameObject.GetComponent<SpriteRenderer>().sprite = floorFilledSprite;
        }
        else if (tileWorld.Type == Tile.TileType.Empty)
        {
            tileGameObject.GetComponent<SpriteRenderer>().sprite = null;
        }
        else
        {
            Debug.LogError("OnTileTypeChanged - Unrecognized tile type");
        }
    }

}
