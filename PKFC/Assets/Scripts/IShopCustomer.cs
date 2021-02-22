using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShopCustomer
{
    void BoughtItem(Items.ItemType itemType);
    bool TrySpendAmount(int dropAmount);
}

