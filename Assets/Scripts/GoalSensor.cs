using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoalSensor : MonoBehaviour
{
    public TextMeshProUGUI goalCounter;
    public TextMeshProUGUI goalText;

    public bool goalScoredText = false;

    public float goals;
    private float messageDuration = 1.5f;

    private Vector3 playerStart; 

    // Start is called before the first frame update
    void Start()
    {
        goals = 0;
        goalCounter.text = "Goals: " + goals;
        playerStart = new Vector3(9.5f, 0.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(goalScoredText == true)
        {
            StartCoroutine(DisableGoalText());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            goals++;
            Instantiate(other.gameObject, playerStart, transform.rotation);
            Destroy(other.gameObject);
            goalCounter.text = "Goals: " + goals;
            goalText.gameObject.SetActive(true);
            goalScoredText = true;
        }
    }

    IEnumerator DisableGoalText()
    {
        yield return new WaitForSeconds(messageDuration);
        goalText.gameObject.SetActive(false);
        goalScoredText = false;
    }
}
