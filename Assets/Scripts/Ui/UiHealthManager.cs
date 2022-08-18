using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UiHealthManager : MonoBehaviour
{
    [SerializeField] Image[] hearts;
    public int HeartsAmount { get; private set; }
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

        for (int i = hearts.Length-1; i >= player.GetComponent<Stats>().Health; i--)
        {
            hearts[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < player.GetComponent<Stats>().Health; i++)
        {
            hearts[i].gameObject.SetActive(true);
        }

    }
}
