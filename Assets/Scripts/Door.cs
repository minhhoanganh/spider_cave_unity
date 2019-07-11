using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public static Door instance;

    private Animator anim;
    private BoxCollider2D box;

    public int collectTablesCount;

    private void Awake()
    {
        MakeInstance();
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }

    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void DecrementCollectTable()
    {
        collectTablesCount--;
        if(collectTablesCount == 0)
        {
            StartCoroutine(OpenDoor());
        }
    }

    IEnumerator OpenDoor()
    {
        anim.Play("Open");
        yield return new WaitForSeconds(.7f);
        box.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Player")
        {
            GameObject.Find("Gameplay Ctrl").GetComponent<GamePlayCtrl>().PlayerDied();
            Debug.Log("Finish");
        }
    }

}
