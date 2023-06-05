using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObj : MonoBehaviour
{
    [SerializeField] Items itemType;

    public Items ItemType { get => itemType;}
}

public enum Items
{
    Bucket,
    Log,
    WoodenBoard,
}
