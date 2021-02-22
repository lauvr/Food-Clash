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
    public int gdrop;
    public int rdrop;
    public int bdrop;
    public int gpotion;
    public int rpotion;
    public int bpotion;

    void Start()
    {
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
}
