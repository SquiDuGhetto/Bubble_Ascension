using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ReverseScaleTwin : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        GrowUp();
    }
    public void GrowUp()
    {
        transform.DOScale(new Vector3(1, 1, 1) ,0.5f);
        print("Tween Complete");
    }

}
