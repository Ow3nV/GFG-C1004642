using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavaScroll : MonoBehaviour
{

    public float scrollSpeedx;
    public float scrollSpeedy;

    Renderer rend;

    // Start is called before the first frame update




    // Update is called once per frame

    void Update()
    {

        float offSetx = Time.time * scrollSpeedx;
        float offSety = Time.time * scrollSpeedy;

        GetComponent<Renderer>().material.mainTextureOffset = new Vector2 (offSetx, offSety);
    }

}