using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class HandleScore : MonoBehaviour
{ 
    [SerializeField] private int highScore = 0;
    private string scoreSaveKey = "accountScore";
    
    // Start is called before the first frame update
    void Start()
    {
        Load();
    }
    
    public void SetHighScore(int scoreAmount)
    {
        if(scoreAmount > highScore) highScore = scoreAmount;
        Save();
    }

    private void Save()
    {
        ES3.Save(scoreSaveKey, highScore);
    }
    
    private void Load()
    {
        if (ES3.KeyExists(scoreSaveKey))
            highScore = ES3.Load<int>(scoreSaveKey);
    }
}
