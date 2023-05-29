using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPopup : MonoBehaviour
{
    [SerializeField] GameObject cannon;
    [SerializeField] Slider slider;
    [SerializeField] Slider verticalSlider;
    [SerializeField] GameObject ball;
    [SerializeField] TMP_InputField massInput;
    [SerializeField] Slider levelSlider;

    [SerializeField] TMP_Text levelSliderText;

    public float rotationAmount = 5f;

    // Start is called before the first frame update
    void Start()
    {
        massInput.text = ball.GetComponent<Rigidbody>().mass.ToString();     //InputField will store the initial value of cannonball mass
        levelSliderText.text = levelSlider.value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Open()                                                   //Opening the Settings will activate the popup - image object.
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void OnRotationChanged()
    {
        Vector3 rotation = new Vector3(0, 180 - slider.value, 0);
        cannon.transform.localEulerAngles = rotation;
    }

    public void OnMassChanged()
    {
        float value = float.Parse(massInput.text);
        ball.GetComponent<Rigidbody>().mass = value;
    }

    public void OnVerticalRotationChanged()
    {
        Vector3 rotation = new Vector3(-66 - verticalSlider.value, 0, 0);
        Transform barrel = cannon.transform.Find("Barrel");
        barrel.transform.localEulerAngles = rotation;   
    }


    }
