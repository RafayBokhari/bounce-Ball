using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Enemy : MonoBehaviour
{
    public float moveDistance = 2f; 
    public float moveDuration = 1f;
    public float endvalue;
    // Start is called before the first frame update
    void Start()
    {
        //DOTween.Init();
        //DOTween.SetTweensCapacity(2000, 100);

        //Vector3 initialPosition = transform.position;
        //endvalue = initialPosition.y - moveDistance;
        Tweeny();
    }

    void Tweeny()
    {
        Debug.Log("Tweeny");
        //transform.DOMoveY(endvalue, duration).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        transform.DOMoveY(endvalue, moveDuration)
           .SetEase(Ease.InOutSine)
           .SetLoops(-1, LoopType.Yoyo);
    }
}
