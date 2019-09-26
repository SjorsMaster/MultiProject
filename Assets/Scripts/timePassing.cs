using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class timePassing : MonoBehaviour
{

    public float speed = 0.01f;
    float timer;
    void FixedUpdate()
    {
        if ((timer * speed / 24) * 360 - 0 < 90 && GetComponent<Light>().intensity < 1.5)
        {
            GetComponent<Light>().intensity += 0.05f * speed;
        }
        else if ((timer * speed / 24) * 360 - 0 > 90 && GetComponent<Light>().intensity > 0)
        {
            GetComponent<Light>().intensity -= 0.05f * speed;
        }

        timer += 0.1f;

        if((timer * speed / 24) * 360 - 0 == 360)
        {
            timer = 0;
        }

        this.transform.localRotation = Quaternion.Euler(((timer * speed / 24) * 360 - 0), ((timer * (speed / 2) / 24) * 360 - 0), 0);
    }
}
