using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoaltenderController : MonoBehaviour
{
    private Vector3 leftStop;
    private Vector3 rightStop;
    private Vector3 ballPosition = new Vector3(9.5f, 0.5f, 0);

    public float goalieSpeed = 1f;
    private float messageDuration = 1.5f;

    public TextMeshProUGUI saveText;

    public GoalSensor goalSensor;

    public bool saveTextEnabled = false;

    // Start is called before the first frame update
    void Start()
    {
        leftStop = new Vector3(-53, transform.position.y, -14.8f);
        rightStop = new Vector3(-53, transform.position.y, 16.1f);

        goalSensor = GameObject.Find("Goal Sensor").GetComponent<GoalSensor>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(leftStop, rightStop, Mathf.PingPong(Time.time, 1f));

        if(saveTextEnabled == true)
        {
            StartCoroutine(DisableSaveText());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Instantiate(other.gameObject, ballPosition, transform.rotation);
            Destroy(other.gameObject);
            saveText.gameObject.SetActive(true);
            saveTextEnabled = true;
            goalSensor.goals--;
            goalSensor.goalCounter.text = "Goals: " + goalSensor.goals;
        }
    }

    IEnumerator DisableSaveText()
    {
        yield return new WaitForSeconds(messageDuration);
        saveText.gameObject.SetActive(false);
        saveTextEnabled = false;
    }
}
