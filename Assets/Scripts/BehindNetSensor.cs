using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BehindNetSensor : MonoBehaviour
{
    private Vector3 playerStart;

    private float messageDuration = 1.5f;

    public TextMeshProUGUI missedText;

    public bool missedTextEnabled = false;

    // Start is called before the first frame update
    void Start()
    {
        playerStart = new Vector3(9.5f, 0.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(missedTextEnabled == true)
        {
            StartCoroutine(DisableMissedText());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Instantiate(other.gameObject, playerStart, transform.rotation);
            Destroy(other.gameObject);
            missedText.gameObject.SetActive(true);
            missedTextEnabled = true;
        }
    }

    IEnumerator DisableMissedText()
    {
        yield return new WaitForSeconds(messageDuration);
        missedText.gameObject.SetActive(false);
        missedTextEnabled = false;
    }
}
