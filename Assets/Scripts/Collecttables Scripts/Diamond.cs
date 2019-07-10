using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(Door.instance != null)
        {
            Door.instance.collectTablesCount++;
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Player")
        {
            Destroy(gameObject);

            if(Door.instance != null)
            {
                Door.instance.DecrementCollectTable();
            }
        }
    }

}
