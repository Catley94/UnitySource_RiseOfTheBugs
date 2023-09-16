using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{
    
    [SerializeField] private SOItem[] itemList;
    
    public SOItem GetItem(int itemID)
    {
        return itemList[itemID];
    }
}
