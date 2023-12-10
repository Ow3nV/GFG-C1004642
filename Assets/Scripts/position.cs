using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class position : MonoBehaviour
{
    private Vector3 MeteorPosition;
    private Quaternion MeteorRotation;
    private float MeteorSpeed;
    private GameObject Changed;
    private GameObject Normal;
    private GameObject Meteor;
    private GameObject FogScreen;
    private GameObject DLight;
    public Material FogWall;
    // Use FogWall
    private bool isChanged = false;
    public Material Sky;
    // Use FS013_Night_Moonless
    // Start is called before the first frame update
    void Start()
    {
        Changed = GameObject.Find("Changed");
        Normal = GameObject.Find("Normal");
        Meteor = GameObject.Find("Meteor");
        FogScreen = GameObject.Find("FogScreenS");
        DLight = GameObject.Find("Directional Light");
        Meteor.transform.position = new Vector3(1823f, 5000f, 1730f);
        MeteorPosition = Meteor.transform.position;
        MeteorRotation = Meteor.transform.rotation;
        MeteorSpeed = 5f;
        Normal.SetActive(true);
        Changed.SetActive(false);
        FogScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {   
        if (MeteorPosition.y > 0 && isChanged == false)
        {
            MeteorPosition -= new Vector3(MeteorSpeed / 400, MeteorSpeed / 100, MeteorSpeed / 400);
            MeteorRotation *= Quaternion.Euler(0.2f, 0.15f, 0.1f);
            MeteorSpeed += 0.02f;
            Meteor.transform.position = MeteorPosition;
            Meteor.transform.rotation = MeteorRotation;
        }
        else if(isChanged==false)
        {
            FogScreen.SetActive(true);
            StartCoroutine(FogScene());
            StartCoroutine(ChangeScene());
            DLight.GetComponent<Light>().intensity = (0.1f);
        }
    }
    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(5f);
        ChangeTerrain();
        StartCoroutine(unFogScene());
        isChanged = true;
        RenderSettings.skybox = Sky;
    }
    IEnumerator FogScene()
    {
        float elapsed = 0f;
        float duration = 5f;
        Color wall = FogWall.color;
        while (elapsed < duration)
        {
            wall.a = Mathf.Lerp(0, 1, (elapsed - 2.5f) / (duration - 2.5f));
            FogWall.color = wall;
            RenderSettings.fogDensity = Mathf.Lerp(0f, 0.05f, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
    IEnumerator unFogScene()
    {
        yield return new WaitForSeconds(1f);
        float elapsed = 0f;
        float duration = 5f;
        Color wall = FogWall.color;
        while (elapsed < duration)
        {
            RenderSettings.fogDensity = (0.05f - Mathf.Lerp(0f, 0.0495f, elapsed / duration));
            wall.a = (1- Mathf.Lerp(0, 1, elapsed / duration));
            FogWall.color = wall;
            elapsed += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(5.2f);
        FogScreen.SetActive(false);
    }
    void ChangeTerrain()
    {
        if (Normal != null)
        {
            Normal.SetActive(false);
        }
        if (Changed != null)
        {
            Changed.SetActive(true);
        }
    }
}
