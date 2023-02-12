using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    private int RandomValue;
    private float timeInterval;

    public bool RowStopped;
    public string StoppedSlot;

    private void Start()
    {
        RowStopped = true;
        GameControll.HandlePulled += StartRotating;
    }
    private void StartRotating()
    {
        StoppedSlot = "";
        StartCoroutine("Rotate");
    }
    private IEnumerator Rotate()
    {
        RowStopped = false;
        timeInterval = 0.025f;
        for(int i = 0; i < 30; i++)
        {
            if(transform.position.y <= -3.5f)
            {
                transform.position = new Vector2(transform.position.x, 1.75f);
            }
                transform.position = new Vector2(transform.position.x,transform.position.y -  0.25f);
            
            yield return new WaitForSeconds(timeInterval);
        }
        RandomValue = Random.Range(60,100);
       
         switch(RandomValue % 3)
        {
            case 1: RandomValue += 2;
                break;
            case 2: RandomValue += 1;
                break;
        }

        for(int i = 0; i< RandomValue; i++)
        {
            if (transform.position.y <= -3.5f)
            {
                transform.position = new Vector2(transform.position.x, 1.75f);
            }
                transform.position = new Vector2(transform.position.x, transform.position.y - 0.25f);
            
            if (i > Mathf.RoundToInt(RandomValue * 0.25f))
                timeInterval = 0.05f;
            if (i > Mathf.RoundToInt(RandomValue * 0.5f))
                timeInterval = 0.1f;
            if (i > Mathf.RoundToInt(RandomValue * 0.75f))
                timeInterval = 0.15f;
            if (i > Mathf.RoundToInt(RandomValue * 0.95f))
                timeInterval = 0.2f;
            yield return new WaitForSeconds(timeInterval);
        }
        if (transform.position.y == -3.5f)
            StoppedSlot = "Diamond";
        else if (transform.position.y == -2f)
            StoppedSlot = "WinterMelon";
        else if (transform.position.y == -1.25)
            StoppedSlot = "Bar";
        else if (transform.position.y == -0.5)
            StoppedSlot = "Seven";
        else if (transform.position.y == 0.25)
            StoppedSlot = "Cherry";
        else if (transform.position.y == 1.15)
            StoppedSlot = "Lemon";
        else if (transform.position.y == -2.75f)
            StoppedSlot = "Crown";
        else if (transform.position.y == 1.75)
            StoppedSlot = "Diamond";
        RowStopped = true;
    }
    private void OnDestroy()
    {
        GameControll.HandlePulled -= StartRotating;
    }
}
