using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICountdown : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countdownText;
    private int startValue = 3;
    private bool isCoundownFinished = false;
    public bool IsCountdownFinished { get { return isCoundownFinished; } }

    private void Start()
    {
        StartCoroutine(FirstSpawnDelay());
    }

    private IEnumerator FirstSpawnDelay()
    {
        for (int i = startValue; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        countdownText.text = "START!";
        yield return new WaitForSeconds(1);
        isCoundownFinished = true;
        Destroy(gameObject);

    }
}
