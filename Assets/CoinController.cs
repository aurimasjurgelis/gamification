using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CoinController : MonoBehaviour
{
    Dictionary<string, int> stats;
    public TextMeshProUGUI coinQuantityText;
    
    void Update()
    {
        if(ProgressionController.Instance)
        {
            stats = ProgressionController.Instance.GetStats();
            coinQuantityText.text = stats["coins"].ToString();
        }
    }
}
