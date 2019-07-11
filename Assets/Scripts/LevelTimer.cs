using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    private Slider slider;
    private GameObject player;
    private float timerBurn = 1f;

    public float timer = 10f;

    private void Awake()
    {
        GetReferences();
    }

    private void Update()
    {
        if (!player)
            return;

        if (timer > 0)
        {
            timer -= timerBurn * Time.deltaTime;
            slider.value = timer;
        }
        else
        {
            GetComponent<GamePlayCtrl>().PlayerDied();
            Destroy(player);
        }
    }

    void GetReferences()
    {
        player = GameObject.Find("Player");
        slider = GameObject.Find("Time Slider").GetComponent<Slider>();

        slider.minValue = 0f;
        slider.maxValue = timer;
        slider.value = slider.maxValue;
    }
}
