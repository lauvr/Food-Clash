using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
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
        gdrop = 0;
        rdrop = 0;
        bdrop = 0;
        gpotion = 0;
        rpotion = 0;
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
}
