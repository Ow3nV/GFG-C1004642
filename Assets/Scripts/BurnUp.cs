using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnUp : MonoBehaviour
{
    private GameObject Meteor;
    private Vector3 MeteorPos;
    private Vector3 Below;
    // Start is called before the first frame update
    void Start()
    {
        Meteor = GameObject.Find("Meteor");
        MeteorPos = Meteor.transform.position;
        Below = new Vector3(0f, 200f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        MeteorPos = Meteor.transform.position;
        this.transform.position = (MeteorPos - Below);
    }
}
