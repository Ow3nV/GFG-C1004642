using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Vector3 CameraPosition;
    public float CameraSpeed;
    public float Sensitivity = 1f;
    private float TurnX;
    private float TurnY;
    private Transform Orientation;
    private GameObject Meteor;
    private float ShakeV = 0f;
    private float ShakeA = 0.2f;
    private Quaternion Rotate;
    // Start is called before the first frame update
    void Start()
    {
        Orientation = GameObject.Find("Main Camera").transform;
        Meteor = GameObject.Find("Meteor");
        CameraPosition = this.transform.position;
        CameraSpeed = 100f;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void moveCamera(Vector3 direction, Transform Orientation)
    {
        float zMove = Mathf.Cos(Orientation.eulerAngles.y * Mathf.PI / 180) * direction.z - Mathf.Sin(Orientation.eulerAngles.y * Mathf.PI / 180) * direction.x;
        float xMove = Mathf.Sin(Orientation.eulerAngles.y * Mathf.PI / 180) * direction.z + Mathf.Cos(Orientation.eulerAngles.y * Mathf.PI / 180) * direction.x;
        transform.position = transform.position + new Vector3(xMove, direction.y, zMove);
    }

    // Update is called once per frame
    void Update()
    {
        CameraPosition = new Vector3(0f, 0f, 0f);
        TurnY += (Input.GetAxis("Mouse Y")*Sensitivity);
        TurnX += (Input.GetAxis("Mouse X")*Sensitivity);
        TurnY = Mathf.Clamp(TurnY, -90f, 90f);
        if (Input.GetKey(KeyCode.W))
        {
            CameraPosition.z += CameraSpeed / 100;
        }
        if (Input.GetKey(KeyCode.S))
        {
            CameraPosition.z -= CameraSpeed / 100;
        }
        if (Input.GetKey(KeyCode.A))
        {
            CameraPosition.x -= CameraSpeed / 100;
        }
        if (Input.GetKey(KeyCode.D))
        {
            CameraPosition.x += CameraSpeed / 100;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            CameraPosition.y += CameraSpeed / 100;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            CameraPosition.y -= CameraSpeed / 100;
        }
        Orientation.rotation = Quaternion.Euler(TurnY, TurnX, 0);
        moveCamera(CameraPosition, Orientation);
        if(Meteor.transform.position.y < 1000 && Meteor.transform.position.y > 1)
        {
            if (ShakeV > 3)
            {
                ShakeA = -0.4f;
            }
            else if (ShakeV < -3)
            {
                ShakeA = 0.4f;
            }
            ShakeV += ShakeA;
            Rotate = Quaternion.Euler(-TurnY, TurnX, ShakeV);
        }
        else
        {
            Rotate = Quaternion.Euler(-TurnY, TurnX, 0);
        }
        this.transform.rotation = Rotate;
    }
}