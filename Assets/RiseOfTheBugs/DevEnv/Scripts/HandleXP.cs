using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleXP : MonoBehaviour
{

    [SerializeField] private int accountXP = 0;
    private string xpSaveKey = "accountXP";
    
    // Start is called before the first frame update
    void Start()
    {
        Load();
    }
    
    public void AddXP(int xpAmount)
    {
        accountXP += xpAmount;
        Save();
    }

    private void Save()
    {
        ES3.Save(xpSaveKey, accountXP);
    }
    
    private void Load()
    {
        if (ES3.KeyExists(xpSaveKey))
            accountXP = ES3.Load<int>(xpSaveKey);
    }
}
