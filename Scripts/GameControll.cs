using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameControll : MonoBehaviour
{
    public static Action HandlePulled = delegate { };
    [SerializeField]
    private Text PrizeText;

    [SerializeField]
    private Row[] Rows;

    [SerializeField]
    private Transform Handle;
    private int prizeValue;
    private bool resultsChecked = false;

    [SerializeField] private AudioClip _clip;
  

    private void Start()
    {
        PrizeText.enabled = false;
    }
    private void Update()
    {
        CheckRow();
       
    }
    private void CheckRow()
    {
        if (!Rows[0].RowStopped || !Rows[1].RowStopped || !Rows[2].RowStopped)
        {
            prizeValue = 0;
            PrizeText.enabled = false;
            resultsChecked = false;
        }
        if (Rows[0].RowStopped && Rows[1].RowStopped && Rows[2].RowStopped)
        {
            CheckResult();
            PrizeText.enabled = true;
            PrizeText.text = "Prize " + prizeValue;
           
        }
    }
    private void OnMouseDown()
    {
        if (Rows[0].RowStopped && Rows[1].RowStopped && Rows[2].RowStopped)
            StartCoroutine("PullHandle");
        AudioManager.Instance.PLaySound(_clip);
       
    }
    //private void Touch()
    //{
    //    if (Rows[0].RowStopped && Rows[1].RowStopped && Rows[2].RowStopped)
    //    {
    //        if (Input.touchCount > 0)
    //        StartCoroutine("PullHandle");
            
    //    }
       
    //}
    private IEnumerator PullHandle()
    {
        for(int  i = 0; i < 20; i+=5)
        {
            Handle.Rotate(0f, 0f, i);
            yield return new WaitForSeconds(0.01f);
        }
        HandlePulled();
        for (int i = 0; i < 20; i += 5)
        {
            Handle.Rotate(0f, 0f, -i);
            yield return new WaitForSeconds(0.01f);
        }
       
    }
    private void CheckResult()
    {
        /// tinh toan an  3 o
        if (Rows[0].StoppedSlot == "Diamond" && Rows[1].StoppedSlot == "Diamond" && Rows[2].StoppedSlot == "Diamond")
            prizeValue = 200;
        else if (Rows[0].StoppedSlot == "WinterMelon" && Rows[1].StoppedSlot == "WinterMelon" && Rows[2].StoppedSlot == "WinterMelon")
            prizeValue = 600;
        else if (Rows[0].StoppedSlot == "Bar" && Rows[1].StoppedSlot == "Bar" && Rows[2].StoppedSlot == "Bar")
            prizeValue = 800;
        else if (Rows[0].StoppedSlot == "Seven" && Rows[1].StoppedSlot == "Seven" && Rows[2].StoppedSlot == "Seven")
            prizeValue = 1500;
        else if (Rows[0].StoppedSlot == "Cherry" && Rows[1].StoppedSlot == "Cherry" && Rows[2].StoppedSlot == "Cherry")
            prizeValue = 3000;
        else if (Rows[0].StoppedSlot == "Lemon" && Rows[1].StoppedSlot == "Lemon" && Rows[2].StoppedSlot == "Lemon")
            prizeValue = 5000;
        else if (Rows[0].StoppedSlot == "Crown" && Rows[1].StoppedSlot == "Crown" && Rows[2].StoppedSlot == "Crown")
            prizeValue = 400;
        /// tinh toan an 2 o
        else if ((Rows[0].StoppedSlot == Rows[1].StoppedSlot) && (Rows[0].StoppedSlot == "Diamond") || (Rows[0].StoppedSlot == Rows[2].StoppedSlot) && (Rows[0].StoppedSlot == "Diamond") || (Rows[1].StoppedSlot == (Rows[2].StoppedSlot) && (Rows[1].StoppedSlot == "Diamond")))
            prizeValue = 100;

        else if ((Rows[0].StoppedSlot == Rows[1].StoppedSlot) && (Rows[0].StoppedSlot == "WinterMelon") || (Rows[0].StoppedSlot == Rows[2].StoppedSlot) && (Rows[0].StoppedSlot == "WinterMelon") || (Rows[1].StoppedSlot == (Rows[2].StoppedSlot) && (Rows[1].StoppedSlot == "WinterMelon")))
            prizeValue = 500;

        else if ((Rows[0].StoppedSlot == Rows[1].StoppedSlot) && (Rows[0].StoppedSlot == "Bar") || (Rows[0].StoppedSlot == Rows[2].StoppedSlot) && (Rows[0].StoppedSlot == "Bar") || (Rows[1].StoppedSlot == (Rows[2].StoppedSlot) && (Rows[1].StoppedSlot == "Bar")))
            prizeValue = 700;

        else if ((Rows[0].StoppedSlot == Rows[1].StoppedSlot) && (Rows[0].StoppedSlot == "Seven") || (Rows[0].StoppedSlot == Rows[2].StoppedSlot) && (Rows[0].StoppedSlot == "Seven") || (Rows[1].StoppedSlot == (Rows[2].StoppedSlot) && (Rows[1].StoppedSlot == "Seven")))
            prizeValue = 1000;

        else if ((Rows[0].StoppedSlot == Rows[1].StoppedSlot) && (Rows[0].StoppedSlot == "Cherry") || (Rows[0].StoppedSlot == Rows[2].StoppedSlot) && (Rows[0].StoppedSlot == "Cherry") || (Rows[1].StoppedSlot == (Rows[2].StoppedSlot) && (Rows[1].StoppedSlot == "Cherry")))
            prizeValue = 2000;

        else if ((Rows[0].StoppedSlot == Rows[1].StoppedSlot) && (Rows[0].StoppedSlot == "Cherry") || (Rows[0].StoppedSlot == Rows[2].StoppedSlot) && (Rows[0].StoppedSlot == "Cherry") || (Rows[1].StoppedSlot == (Rows[2].StoppedSlot) && (Rows[1].StoppedSlot == "Cherry")))
            prizeValue = 2000;

        else if ((Rows[0].StoppedSlot == Rows[1].StoppedSlot) && (Rows[0].StoppedSlot == "Lemon") || (Rows[0].StoppedSlot == Rows[2].StoppedSlot) && (Rows[0].StoppedSlot == "Lemon") || (Rows[1].StoppedSlot == (Rows[2].StoppedSlot) && (Rows[1].StoppedSlot == "Lemon")))
            prizeValue = 4000;

        else if ((Rows[0].StoppedSlot == Rows[1].StoppedSlot) && (Rows[0].StoppedSlot == "Crown") || (Rows[0].StoppedSlot == Rows[2].StoppedSlot) && (Rows[0].StoppedSlot == "Crown") || (Rows[1].StoppedSlot == (Rows[2].StoppedSlot) && (Rows[1].StoppedSlot == "Crown")))
            prizeValue = 300;
        resultsChecked = true;
      
    }

}
