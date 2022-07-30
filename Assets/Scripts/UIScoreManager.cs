using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScoreManager : MonoBehaviour
{   
    [SerializeField] TextMeshProUGUI scoreText;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = 2.ToString();
    }
}
