using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAndAir : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Player")
        {
            if(gameObject.name == "Air")
            {
                GameObject.Find("Gameplay Ctrl").GetComponent<AirTimer>().air += 15f;
            } else
            {
                GameObject.Find("Gameplay Ctrl").GetComponent<LevelTimer>().timer += 15f;
            }
            Destroy(gameObject);
        }
    }
}
