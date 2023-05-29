using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    [SerializeField] GameObject cannon;
    public float rotationAmount = 55f;
    float r;

    void Update()
    {
        MyInput();
    }

    public void MyInput()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Rotate(-rotationAmount);
            GetComponent<LaunchProjectile>().DrawProjection();
        }
        else if (Input.GetKey(KeyCode.E))
        {
            Rotate(rotationAmount);
            GetComponent<LaunchProjectile>().DrawProjection();
        }
        else if (Input.GetKey(KeyCode.W))
        {
            BarrelRotate(-rotationAmount);
            GetComponent<LaunchProjectile>().DrawProjection();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            BarrelRotate(rotationAmount);
            GetComponent<LaunchProjectile>().DrawProjection();
        }
    }

    private void Rotate(float amount)
    {
        float angle = Mathf.SmoothDampAngle(cannon.transform.eulerAngles.y, cannon.transform.eulerAngles.y + amount, ref r, 0.1f);
        cannon.transform.rotation = Quaternion.Euler(0, angle, 0);


        //float rotation = rotationAmount * Time.deltaTime;
        //float speed = 3f;
        //cannon.transform.rotation = Quaternion.Lerp(cannon.transform.rotation, Quaternion.Euler(Vector3.up * amount), Time.deltaTime * speed);

        //cannon.transform.Rotate(Vector3.up * amount);
    }

    private void BarrelRotate(float amount)
    {
        
        Transform barrel = cannon.transform.Find("Barrel");
        float angle = Mathf.SmoothDampAngle(barrel.transform.eulerAngles.x, barrel.transform.eulerAngles.x - amount, ref r, 0.1f);
        barrel.transform.localRotation = Quaternion.Euler(angle, 0, 0);

        /* Transform barrel = cannon.transform.Find("Barrel");

        float angle = barrel.transform.localEulerAngles.x - amount;
        float minAngle = -45;
        float maxAngle = 45;
        angle = Mathf.Clamp(angle, minAngle, maxAngle); // Optionally, you can add angle clamping to restrict the rotation within certain limits

        barrel.transform.localRotation = Quaternion.Euler(angle, 0, 0); */

    }
}
