using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour, IShopCustomer
{
    [SerializeField]
    private Text greend;
    [SerializeField]
    private Text redd;
    [SerializeField]
    private Text blued;
    [SerializeField]
    private Text greenp;
    [SerializeField]
    private Text redp;
    [SerializeField]
    private Text bluep;
    private Material currentMat;
    public int gdrop;
    public int rdrop;
    public int bdrop;
    public int gpotion;
    public int rpotion;
    public int bpotion;
    private ChestDrops chest;
    private bool firstTime = true;
    private int randR;
    private int randB;
    private int randG;

    void Start()
    {
        randR = Random.Range(1, 5);
        randB= Random.Range(1, 5);
        randG = Random.Range(1, 5);
        gdrop = 5;
        rdrop = 5;
        bdrop = 5;
        gpotion = 0;
        rpotion = 0;
        bpotion = 0;
    }
    void Update()
    {
        greend.text = gdrop.ToString();
        redd.text = rdrop.ToString();
        blued.text = bdrop.ToString();
        greenp.text = gpotion.ToString();
        redp.text = rpotion.ToString();
        bluep.text = bpotion.ToString();
    }
    public void Addresources (int value, string tag)
    {
        if (tag == "GDrop")
        {
            gdrop = gdrop + value;
        }
        else if(tag == "RDrop")
        {
            rdrop = rdrop + value;
        }
        else if(tag == "BDrop")
        {
            bdrop = bdrop + value;
        }
    }

    public void BoughtItem(Items.ItemType itemType)
    {
        Debug.Log("Bought Item: " + itemType);
       
    }

    public bool TrySpendAmount(int dropAmount)
    {
        if (rdrop >= dropAmount)
        {
            rpotion += 1;
            rdrop -= 5;
            return true;
        }
        if (bdrop >= dropAmount)
        {
            bpotion += 1;
            bdrop -= 5;
            return true;
        }
        if (gdrop >= dropAmount)
        {
            gpotion += 1;
            gdrop -= 5;
            return true;
        }
        else
        {
            return false;
        }
    }



    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        gdrop = data.greenDrop;
        bdrop = data.blueDrop;
        rdrop = data.redDrop;
        gpotion = data.greenPotion;
        bpotion = data.bluePotion;
        rpotion = data.redPotion;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Chest"))
        {
            if (firstTime == true)
            {
                Debug.Log("Chest");
                rdrop = rdrop + randR;
                bdrop = bdrop + randB;
                gdrop = gdrop + randG;
                firstTime = false;
            }
            else
            {
                Debug.Log("Chest already open");
            }

        }
    }
}

