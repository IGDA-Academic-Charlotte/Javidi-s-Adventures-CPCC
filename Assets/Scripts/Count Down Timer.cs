using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public Text timer;
    public float time;

    public string endMenu;
    //public string nextLevel;
    //public string loadLevel;

    private void Start()
    {
        StartCountDownTimer();
    }

    void StartCountDownTimer()
    {
        timer.text = "Time Left: ";
        //InvokeRepeating("UpdateTimer", 0.0f, 0.01667f);
    }

    private void FixedUpdate()
    {
        if (timer != null)
        {
            time -= Time.deltaTime;
            string minutes = Mathf.Floor(time / 60).ToString("00");
            string seconds = (time % 60).ToString("00");
            string fraction = ((time * 100) % 100).ToString("00");
            timer.text = "Time Left: " + minutes + ":" + seconds + ":" + fraction;
        }

        if (time <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "winnerObject")
        {
            SceneManager.LoadScene(nextLevel);
        }
    }*/
}
