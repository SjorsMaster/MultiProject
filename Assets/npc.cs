using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc : MonoBehaviour
{
    public GameObject head;
    public GameObject box;
    float speed = .05f;

    public Vector3 offshead;
    Quaternion toRotation;
    Vector3 direction;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(head.transform.position, box.transform.position) <= 5)
        {
            direction = box.transform.position - head.transform.position;
            toRotation = Quaternion.LookRotation(transform.up, direction);
            if (toRotation.x < .4f && toRotation.x > -.4f)
            {
                head.transform.rotation = Quaternion.Lerp(head.transform.rotation, toRotation, speed);
            }
            else
            {
                head.transform.rotation = Quaternion.Slerp(head.transform.rotation, new Quaternion(0, 0.7f, 0.7f, 0), speed); ;
            }
        }
        else
        {
            head.transform.rotation = Quaternion.Slerp(head.transform.rotation, new Quaternion(0, 0.7f, 0.7f, 0), speed); ;
        }
    }
}
