using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeGame : MonoBehaviour
{
    float roundStartTime;
    int waitTime;
    float startDelayTime = 3;
    bool inProgress = false;

    // Start is called before the first frame update
    void Start()
    {
        print("Press Spacebar once you think the time has passed.");
        Invoke("SetRandomTime", startDelayTime);

    }

    // Update is called once per frame
    void Update()
    {
        handleInput();


    }

    void handleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && inProgress)
        {
            inProgress = false;
            float playerWaitTime = Time.time - roundStartTime;
            float error = Mathf.Abs(waitTime - playerWaitTime);

            print("You waited for " + playerWaitTime + "seconds.");
            print("Your difference was " + error + " seconds.");
            Invoke("SetRandomTime", startDelayTime);
        }
    }

    void SetRandomTime()
    {
        waitTime = Random.Range(3, 16);
        roundStartTime = Time.time;
        inProgress = true;
        print(waitTime + " seconds.");
    }

}
