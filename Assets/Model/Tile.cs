using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{

    #region Tile Type stuff
    public enum TileType { Empty, Floor};

    TileType _type = TileType.Empty;

    Action<Tile> _tileTypeChangedCallback;

    public TileType Type
    {
        get => _type;
        set
        {
            TileType oldType = _type;
            _type = value;
            if (_tileTypeChangedCallback != null && oldType != _type)
            {
                _tileTypeChangedCallback(this);
            }
        }
    }

    public void RegisterTileTypeChangeCallback(Action<Tile> callback)
    {
        _tileTypeChangedCallback += callback;
    }
    public void UnRegisterTileTypeChangeCallback(Action<Tile> callback)
    {
        _tileTypeChangedCallback -= callback;
    }

    #endregion

    LooseObject looseObject;
    InstalledObject installedObject;

    World _world;
    int _xPosition;
    int _yPosition;

    public int XPosition => _xPosition;
    public int YPosition => _yPosition;

    public Tile(World world, int x, int y)
    {
        this._world = world;
        this._xPosition = x;
        this._yPosition = y;
    }


}
