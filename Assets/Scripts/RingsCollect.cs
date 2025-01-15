using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using DG.Tweening;

public class RingsCollect : MonoBehaviour
{

    public int Ring = 6;
    public GameObject[] uirings;
    public static RingsCollect Instance;
    public GameObject box;
    public float endvalue;
    public float duration;
    public GameObject level;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        //else
        //{
        //    Destroy(gameObject);    
        //}

        //DOTween.SetTweensCapacity(3000, 200);
        level.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTweenComplete()
    {
        Debug.Log("kill Tween");
    }



    public void Coincollector()
    {
        if (Ring > 0)
        {
            Ring--;

            if (Ring >= 0 && Ring < uirings.Length)
            {
                Destroy(uirings[Ring]);

            }
        }
        if (Ring == 0)
        {
            box.transform.DOMoveY(endvalue, duration);
            level.SetActive(true);
        }
        //box.transform.DOKill();
    }

}
    


        
    

