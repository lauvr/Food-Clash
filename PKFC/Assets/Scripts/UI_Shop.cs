using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;

public class UI_Shop : MonoBehaviour
{
    private Transform container;
    private Transform shopItemTemplate;
    private IShopCustomer shopCustomer;

    private void Awake()
    {
        container = transform.Find("container");
        shopItemTemplate = container.Find("shopitemTemplate");
        shopItemTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {

        CreateItemButton(Items.ItemType.RedPotion,Items.GetSprite(Items.ItemType.RedPotion), "Red Potion", Items.GetCost(Items.ItemType.RedPotion),0);
        CreateItemButton(Items.ItemType.BluePotion, Items.GetSprite(Items.ItemType.BluePotion), "Blue Potion", Items.GetCost(Items.ItemType.BluePotion), 2);
        CreateItemButton(Items.ItemType.GreenPotion, Items.GetSprite(Items.ItemType.GreenPotion), "Green Potion", Items.GetCost(Items.ItemType.GreenPotion), 4);

        Hide();
    }

    private void CreateItemButton(Items.ItemType itemType ,Sprite itemSprite, string itemName, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        shopItemTransform.gameObject.SetActive(true);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();
        float shopItemHeight = 30f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        shopItemTransform.Find("Item").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("Price").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());
        shopItemTransform.Find("Image").GetComponent<Image>().sprite = itemSprite;
        
        shopItemTransform.GetComponent<Button_UI>().ClickFunc = () => {
            TryBuyItem(itemType);
        };
        
        
    }

    private void TryBuyItem(Items.ItemType itemType)
    {
        if (shopCustomer.TrySpendAmount(Items.GetCost(itemType)))
        {
            shopCustomer.BoughtItem(itemType);
        }
        else
        {
            Debug.Log("Cant buy item, not enough drops");
        }
        
    }

    public void Show(IShopCustomer shopCustomer)
    {
        this.shopCustomer = shopCustomer;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }


}
