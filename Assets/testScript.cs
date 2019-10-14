using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour
{
    int frameCount = 0;
    // Start is called before the first frame update
    void Start()
    {

        print("Hey");
        float distance = GetDistance(0, 5, 10, 15);
        print(distance);

    }

    // Update is called once per frame
    void Update()
    {
        print(frameCount);
        frameCount = frameCount + 1;
    }

    float GetDistance(float x1, float y1, float x2, float y2)
    {
        float dX = x2 - x1;
        float dy = y2 - y1;
        float cSquared = (dX * dX) + (dy * dy);
        float distance = Mathf.Sqrt(cSquared);
        return distance;
    }
}
