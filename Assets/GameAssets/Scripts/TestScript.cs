using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        MobileInput.instance.ON_Tap += Tap;
        MobileInput.instance.ON_DoubleTap += DoubleTap;
        if (MobileInput.instance.enableEvents)
            MobileInput.instance.ON_Swipe += Swipe;
    }

    private void Swipe(MobileInput.SwipeDirection obj)
    {
        if (obj == MobileInput.SwipeDirection.TOP) text.text = "TOP";
        if (obj == MobileInput.SwipeDirection.DOWN) text.text = "DOWN";
        if (obj == MobileInput.SwipeDirection.LEFT) text.text = "LEFT";
        if (obj == MobileInput.SwipeDirection.RIGHT) text.text = "RIGHT";
        if (obj == MobileInput.SwipeDirection.TAP) text.text = "Swipe TAP";
    }

    // Update is called once per frame
    void Update()
    {
        //if (MobileInput.instance.Tap)
        //{
        //    text.text = "TAP";
        //}
        //if (MobileInput.instance.DoubleTap)
        //{
        //    text.text = "Double TAP";
        //}
        //MobileInput.SwipeDirection swipe = MobileInput.instance.Swipe();
        //if (swipe == MobileInput.SwipeDirection.TOP) text.text = "TOP";
        //if (swipe == MobileInput.SwipeDirection.DOWN) text.text = "DOWN";
        //if (swipe == MobileInput.SwipeDirection.LEFT) text.text = "LEFT";
        //if (swipe == MobileInput.SwipeDirection.RIGHT) text.text = "RIGHT";
        //if (swipe == MobileInput.SwipeDirection.TAP) text.text = "TAP";

    }

    private void Tap()
    {
        text.text = "TAP";
    }
    private void DoubleTap()
    {
        text.text = "DOUBLETAP";
    }
}
