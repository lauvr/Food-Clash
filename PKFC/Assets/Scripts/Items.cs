using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public enum ItemType
    {
        RedPotion,
        BluePotion,
        GreenPotion,
    }

    public static int GetCost(ItemType itemtype)
    {
        switch (itemtype)
        {
            default:
            case ItemType.RedPotion: return 5;
            case ItemType.BluePotion: return 5;
            case ItemType.GreenPotion: return 5;
        }
    }


    public static Sprite GetSprite(ItemType itemtype)
    {
        switch (itemtype)
        {
            default:
            case ItemType.RedPotion: return GameAssets.i.redDrop;
            case ItemType.BluePotion: return GameAssets.i.blueDrop;
            case ItemType.GreenPotion: return GameAssets.i.greenDrop;
        }
    }
}
