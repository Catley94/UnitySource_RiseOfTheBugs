using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemStorage : MonoBehaviour
{
    
    [SerializeField] private GameObject itemPrefab;
    private List<SOItem> items = new List<SOItem>();
    private List<int> itemIDs = new List<int>();
    
    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItemToStorage(int itemID)
    {
        SOItem item = GameObject.Find("GameManager").GetComponent<ItemList>().GetItem(itemID);
        items.Add(item);
        itemIDs.Add(itemID);
        GameObject itemObj = Instantiate(itemPrefab, transform);
        itemObj.GetComponentInChildren<TMP_Text>().text = item.name[0].ToString().ToUpper();
        Save();

    }

    public int GetItemStorageCount()
    {
        return items.Count;
    }

    private void Save()
    {
        ES3.Save("ItemStorageIDs", itemIDs);
    }

    private void Load()
    {
        if (ES3.KeyExists("ItemStorageIDs"))
        {
            itemIDs = ES3.Load<List<int>>("ItemStorageIDs", new List<int>());
        }
        
        foreach (int itemID in itemIDs)
        {
            SOItem item = GameObject.Find("GameManager").GetComponent<ItemList>().GetItem(itemID);
            items.Add(item);
            GameObject itemObj = Instantiate(itemPrefab, transform);
            itemObj.GetComponentInChildren<TMP_Text>().text = item.name[0].ToString().ToUpper();
        }

    }


}
