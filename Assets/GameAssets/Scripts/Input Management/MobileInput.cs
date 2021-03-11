using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This Class is to handle all Mobile input like tap, double tap, swipes
public class MobileInput : MonoBehaviour
{
    //Implementing Singleton in this Class
    public static MobileInput instance;
    // To get Total touch count that is currently on screen
    public int CurrentTouchCount { get { return Input.touchCount; } }
    // To get if their is a tap
    public bool Tap { get { return m_tap; } private set { m_tap = value; } }
    // To detect double tap
    public bool DoubleTap { get { return m_DoubleTap; } private set { m_DoubleTap = value; } }
    // a enum to have all swipe posibilities
    public enum SwipeDirection { TOP,DOWN,LEFT,RIGHT,TAP,NONE}

    // for second and thrid tap calculation
    public float tapCancelTime = 1f;
    // to determine how long of a swipe we need and tap
    public float swipeRange,tapRange;
    //for excuting events
    public bool enableEvents;
    
    // TO store the tap and doubletap if happened
    private bool m_tap,m_DoubleTap;
    //To keep count of taps
    private int tapCount;
    // To keep track of last tap time
    private float lastTap;
    //Swipe Related Fields
    private Vector2 startTouchPosition, currentPosition, endTouchPosition;
    // this field is to stop detecting swipes after a spicfic range
    private bool stopTouch;
    private bool isTap;

    //Events
    public event Action ON_Tap;
    public event Action ON_DoubleTap;
    public event Action<SwipeDirection> ON_Swipe;
    

    private void Awake()
    {
        //assigning the instance
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            //destroying the gameobject if there is two more
            Destroy(gameObject);
            Debug.LogError("Two MOBILEINPUT INSTANCE CREATED");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        lastTap = 10;
        ON_Tap += TapFunction;
    }

    // Update is called once per frame
    void Update()
    {
        //after the past time resetting the count
        if (lastTap > tapCancelTime) tapCount = 0 ;
        if (tapCount >= 1)
        {
            // keeping track of last tap time
            lastTap += Time.deltaTime;
        }
        if (CurrentTouchCount >= 1)
        {
            //executing swipe for events
            if (enableEvents)
            {
                if (Swipe() == SwipeDirection.TAP)
                {
                    isTap = true;
                }
                else
                    isTap = false;
            }
            // checking for tap
            m_tap = TapFunc();
        }
        
        
    }
    private bool TapFunc()
    {
        
        // getting the info if the touch is endded or not
        bool touch = (Input.GetTouch(0).phase == TouchPhase.Ended);
        if (touch)
        {
            //checking if the last tap time is stil inside the tap cancel Time range
            if (lastTap < tapCancelTime)
            {
                // increacing the tap count
                if (isTap)
                {
                    tapCount++;
                    m_DoubleTap = DoubleTapFunc(); 
                }
            }
            else
            {
               // Debug.Log("tap");
                if (isTap)
                {
                    //executing event ON_Tap
                    ON_Tap?.Invoke();
                    tapCount = 1;
                }
                
                
                // resetting the tap count 
                
                m_DoubleTap = false;

            }
            // resetting last tap time
            lastTap = 0;
            return touch;

        }
        return false;
    }
    private bool DoubleTapFunc()
    {

        // if the tap count is 2 then excute the code
        if(tapCount == 2)
        {
            Debug.Log("Double Tap");
            //executing event ON_DoubleTap
            ON_DoubleTap?.Invoke();
            //resetting the last tap time
            lastTap = 0;
            return true;
        }
        return false;
    }

    public SwipeDirection Swipe()
    {
        // creating a temp variable
        SwipeDirection swipeDir = SwipeDirection.NONE;
        if(CurrentTouchCount>=1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // at the began phase assign the startTouchPosition
            startTouchPosition = Input.GetTouch(0).position;
        }
        if(CurrentTouchCount >=1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            //updating current position in every move
            currentPosition = Input.GetTouch(0).position;
            // get the direction and distance from the start and current position
            Vector2 Direction = currentPosition - startTouchPosition;
            //this is to stop detecting swipe after certain distance
            if (!stopTouch)
            {
                //check for left swipe
                if(Direction.x < -swipeRange)
                {
                    //left swipe
                    swipeDir = SwipeDirection.LEFT;
                    stopTouch = true;
                }
                //check for right swipe
                else if (Direction.x > swipeRange)
                {
                    //right swipe
                    swipeDir = SwipeDirection.RIGHT;
                    stopTouch = true;
                }
                //check for top swipe
                else if (Direction.y > swipeRange)
                {
                    //top swipe
                    swipeDir = SwipeDirection.TOP;

                    stopTouch = true;
                }
                //check for Down swipe
                else if (Direction.y < -swipeRange)
                {
                    //down swipe
                    swipeDir = SwipeDirection.DOWN;

                    stopTouch = true;
                }
            }
        }
        // check for end phase and posibility for a tap
        if(CurrentTouchCount>=1 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            //disabling this so that detect swipe from now on
            stopTouch = false;
            endTouchPosition = Input.GetTouch(0).position;
            Vector2 direction = endTouchPosition - startTouchPosition;
            // checking for a tap 
            //Debug.Log($"{direction.x}  +  {direction.y}");
            if(Mathf.Abs(direction.x) < tapRange && Mathf.Abs(direction.y) < tapRange)
            {
                swipeDir = SwipeDirection.TAP;
                //Debug.Log("Swipe tap end");
            }
        }
        if (!(swipeDir == SwipeDirection.TAP))
        {
            //executing event ON_Swipe
            ON_Swipe?.Invoke(swipeDir);
        }
        //Debug.Log(swipeDir);
        //return the detected swipe
        return swipeDir;
    }

    private void TapFunction()
    {

    }
}
