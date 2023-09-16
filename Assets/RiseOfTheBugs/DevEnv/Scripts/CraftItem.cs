using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftItem : MonoBehaviour
{
    
    [SerializeField] private ItemStorage itemStorage;

    // Start is called before the first frame update
    void Start()
    {
        itemStorage = GameObject.FindWithTag("UI_ItemStorage").GetComponent<ItemStorage>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Craft(int itemID)
    {
        if (itemStorage.GetItemStorageCount() < 8)
        {
            itemStorage.AddItemToStorage(itemID);
        }

    }

}
