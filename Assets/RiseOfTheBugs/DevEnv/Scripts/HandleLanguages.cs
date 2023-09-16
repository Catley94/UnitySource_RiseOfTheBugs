using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HandleLanguages : MonoBehaviour
{
    
    [SerializeField] private Button basicButton;
    [SerializeField] private Button jsButton;
    [SerializeField] private Button cSharpButton;
    [SerializeField] private Button craftPatchButton;
    [SerializeField] private Button craftFixButton;
    [SerializeField] private Button craftImprovementButton;
    [SerializeField] private TMP_Text patchUsesText;
    [SerializeField] private TMP_Text fixUsesText;
    [SerializeField] private TMP_Text improvementUsesText;
    [SerializeField] private TMP_Text patchCapText;
    [SerializeField] private TMP_Text fixCapText;
    [SerializeField] private TMP_Text improvementCapText;

    private int fixesUsesCap = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        SetFixesLevelThreshold();
        //TODO: Get Saved Data:
        /*
         * Check what languages have been unlocked.
         * Check what Fixes are unlocked for each language.
         * Update the successful uses for each Item (Patch, Fix, Improvement).
         */
    }

    private void SetFixesLevelThreshold()
    {
        patchCapText.text = fixesUsesCap.ToString();
        fixCapText.text = fixesUsesCap.ToString();
        improvementCapText.text = fixesUsesCap.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
