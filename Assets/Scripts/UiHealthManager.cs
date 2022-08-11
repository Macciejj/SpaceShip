using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UiHealthManager : MonoBehaviour
{
    [SerializeField] Image[] hearts;
    private PlayerDestroyer player;
    
    private void Awake()
    {
        player = FindObjectOfType<PlayerDestroyer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        SetHearts();
    }

    private void SetHearts()
    {
        for (int i = hearts.Length-1; i >= player.GetComponent<Stats>().health; i--)
        {
            hearts[i].gameObject.SetActive(false);
        }

    }
}
