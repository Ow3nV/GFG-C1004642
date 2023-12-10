using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRotate : MonoBehaviour
{
    private float RotaionSpeed;
    private Quaternion ShipRotation;
    private bool ChangeR;
    // Start is called before the first frame update
    void Start()
    {
        ShipRotation = this.transform.rotation;
        ChangeR = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.rotation.eulerAngles.z > 15 && this.transform.rotation.eulerAngles.z < 33 && ChangeR)
        {
            ChangeR = false;
            RotaionSpeed = 0.0f;
        }
        else if (this.transform.rotation.eulerAngles.z < 345 && this.transform.rotation.eulerAngles.z > 327 && ChangeR==false)
        {
            ChangeR = true;
            RotaionSpeed = 0.0f;
        }
        if (ChangeR)
        {
            ShipRotation *= Quaternion.Euler(0.0f, 0.0f, RotaionSpeed);
            if (this.transform.rotation.eulerAngles.z > 20)
            {
                RotaionSpeed += 0.0025f;
            }
            else
            {
                RotaionSpeed -= 0.0025f;
            }
        }
        else
        {
            ShipRotation *= Quaternion.Euler(0.0f, 0.0f, -RotaionSpeed);
            if (this.transform.rotation.eulerAngles.z > 20)
            {
                RotaionSpeed -= 0.0025f;
            }
            else
            {
                RotaionSpeed += 0.0025f;
            }
        }
        this.transform.rotation = ShipRotation;
    }
}
