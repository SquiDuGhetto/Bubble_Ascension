using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ReverseScaleTwinButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        GrowUp();
    }
    public void GrowUp()
    {
        transform.DOScale(new Vector3(4, 4, 0) ,0.5f);
        print("Tween Complete");
    }

}
