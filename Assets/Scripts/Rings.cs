using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Rings : MonoBehaviour
{
   public bool iscollect = false;
    public bool isaudioplay = false;
    // public UIManager manager;
    
    private void Start()
    {
        //manager = GetComponent<UIManager>();

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
            Debug.Log("hhhh");
            //manager.AddScore(500);
            Audioply();
           

        }
    }
    public void Collect()
    {
        if (!iscollect)
        {
            iscollect = true;
            RingsCollect.Instance.Coincollector();
            UIManager.Instance.AddScore(500);

            //lastrings();
        }
    }
    public void Audioply()
    {
        if (!isaudioplay)
        {
            isaudioplay=true;
            AudioManager.Instance.Play();

        }
    }
    //public void lastrings()
    //{
    //    for (int i = lastring; i >=14 ; i--)
    //    {
    //       lastring--;


    //        if (lastring == 0)
    //        {
    //            box.transform.DOMoveY(endvalue, duration);
    //        }
    //    }
    //}

    

}
