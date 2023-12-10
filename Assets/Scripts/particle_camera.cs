using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle_camera : MonoBehaviour
{
    private GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Camera.transform.position;
    }
}
