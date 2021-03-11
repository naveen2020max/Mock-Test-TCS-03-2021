using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed=1;
    public Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        if (MobileInput.instance.enableEvents)
        {
            MobileInput.instance.ON_Swipe += SwipeMovement;
        }
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //function to execute when left swipe
    private void SwipeMovement(MobileInput.SwipeDirection _swipe)
    {
        switch (_swipe)
        {
            case MobileInput.SwipeDirection.TOP:
                //transform.position += Vector3.up;
                body.MovePosition(transform.position + Vector3.up * speed);
                break;
            case MobileInput.SwipeDirection.DOWN:
                //transform.position -= Vector3.up;
                body.MovePosition(transform.position - Vector3.up * speed);
                break;
            case MobileInput.SwipeDirection.LEFT:
                body.MovePosition(transform.position + Vector3.left * speed);
                //transform.position += Vector3.left;
                break;
            case MobileInput.SwipeDirection.RIGHT:
                body.MovePosition(transform.position + Vector3.right * speed);
                //transform.position += Vector3.right;
                break;
            case MobileInput.SwipeDirection.TAP:
                break;
            case MobileInput.SwipeDirection.NONE:
                break;
            default:
                break;
        }
    }
    

    public Vector3 GetPosition()
    {
        return new Vector3(transform.position.x, transform.position.y, -10);
    }
    public Vector2 GetPosition2D()
    {
        return new Vector2(transform.position.x, transform.position.y);
    }
    public void SetPosition(Vector2 vec)
    {
        transform.position = vec;
    }
    public void MovePosition(Vector2 vec)
    {
        body.MovePosition(((Vector2)transform.position + vec));
    }
}
