using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int greenPotion;
    public int bluePotion;
    public int redPotion;
    public int greenDrop;
    public int blueDrop;
    public int redDrop;


    public PlayerData(Inventory inv)
    {
        greenPotion = inv.gpotion;
        bluePotion = inv.bpotion;
        redPotion = inv.rpotion;
        greenDrop = inv.gdrop;
        blueDrop = inv.bdrop;
        redDrop = inv.rdrop;
    }
}
