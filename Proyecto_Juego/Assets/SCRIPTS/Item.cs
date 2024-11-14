using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable object/Item")]

public class Item : ScriptableObject
{
    public TileBase tile;
    public Sprite image;
    public ItemType type;
    public ActionType actionType;
    public Vector2Int range = new Vector2Int(5, 4);


    //[Header("Only gameplay")]
    
    //[Header("Only UI")]

    //[Header("Both")]


    public enum ItemType
    {
        BuildingBlock,
        Tool
    }

    public enum ActionType
    {
        Dig,
        Mine
    }

}