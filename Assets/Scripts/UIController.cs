using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] SettingsPopup settingsPopup;
    [SerializeField] GameObject cannon;
    [SerializeField] TMP_Text scoreText;
    private bool isOpen;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        settingsPopup.Close();
        isOpen = false;
    }

    void OnEnable()
    {
        Messenger.AddListener(GameEvent.OBSTACLE_HIT, UpdateScore);
        Messenger.AddListener(GameEvent.BASKET_SCORED, UpdateScore);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !isOpen)               //Settings open by pressing Tab key
        {
            settingsPopup.Open(); 
            isOpen = true;
            cannon.GetComponent<LaunchProjectile>().enabled = false;   //Disable projectile launching when settings are open
        }else if (Input.GetKeyDown(KeyCode.Tab) && isOpen)
        {
            settingsPopup.Close();
            isOpen = false;
            cannon.GetComponent<LaunchProjectile>().enabled = true;   //Enable projectile launching when settings are closed again
        }
        }

    void UpdateScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

}




