using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLaunch : MonoBehaviour
{
    private GameObject Meteor;
    private float Acceleration=0.03f;
    private float Rotate = -90;
    private float CircleR = 420f;
    private float CircleS = 0.2f;
    private Vector3 Middle = new Vector3(500f, 0f, 500f);
    private Vector3 RocketOffset;
    private float angle = Mathf.PI;
    private bool Locked = false;
    private bool Locked2 = false;
    private GameObject Blast;
    private GameObject Fire;
    // Start is called before the first frame update
    void Start()
    {
        Meteor = GameObject.Find("Meteor");
        Blast = GameObject.Find("Rocket Blast");
        Fire = GameObject.Find("/rocket/Rocket Fire");
        Blast.SetActive(false);
        Fire.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Meteor.transform.position.y < 3500 && Meteor.transform.position.y > 2500)
        {
            Blast.SetActive(true);
            Fire.SetActive(true);
        }
        else if(Meteor.transform.position.y < 2500 && Meteor.transform.position.y > 0)
        {
            Blast.SetActive(false);
            this.transform.position += new Vector3(0f,Acceleration,0f);
            Acceleration *= 1.0021f;
        }
        else if(Meteor.transform.position.y <= 0 && Rotate < 0 && !Locked)
        {
            this.transform.rotation = Quaternion.Euler(Rotate, 0, 0);
            Rotate += 0.05f;
        } 
        else if (Meteor.transform.position.y <= 0 && Rotate > -90 && !Locked2)
        {
            Locked = true;
            this.transform.rotation = Quaternion.Euler(0, Rotate, 0);
            Rotate -= 0.1f;
            RocketOffset = this.transform.position - Middle;
        }
        else if(Meteor.transform.position.y <= 0)
        {
            Locked2 = true;
            angle += (Time.deltaTime * CircleS);
            float x = Mathf.Sin(angle) * CircleR;
            float z = Mathf.Cos(angle) * CircleR;
            float RotationAngle = 90 + (Mathf.Rad2Deg * angle);
            this.transform.position = Middle + new Vector3(x, RocketOffset.y, z);
            this.transform.rotation = Quaternion.Euler(0, RotationAngle, 0);
        }
    }
}
