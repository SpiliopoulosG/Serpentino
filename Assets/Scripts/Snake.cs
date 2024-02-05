using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Snake : MonoBehaviour
{
    Vector2 startTouchPosition;
    Vector2 endTouchPosition;
    private bool alive = true;
    public float speed = 5f;
    public float wrapBoundaryX = 29.5f;
    public float wrapBoundaryY = 19.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( alive == false ) {
            SceneManager.LoadScene("Game");
        }

        if ( Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if ( Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) {
            endTouchPosition = Input.GetTouch(0).position;
            
            float horizontalSwipe = Mathf.Abs(endTouchPosition.x - startTouchPosition.x);
            float verticalSwipe = Mathf.Abs(endTouchPosition.y - startTouchPosition.y);
            Vector3 currentPosition = transform.position;

            if (horizontalSwipe > verticalSwipe) {
                if (endTouchPosition.x < startTouchPosition.x)
                {
                    Debug.Log("Swipe Left");
                    transform.position = new Vector3(currentPosition.x - 2, currentPosition.y, currentPosition.z);
                    Rotate(90f);
                }
                else if (endTouchPosition.x > startTouchPosition.x)
                {
                    Debug.Log("Swipe Right");
                    transform.position = new Vector3(currentPosition.x + 2, currentPosition.y, currentPosition.z);
                    Rotate(270f);
                }
            } else {
                if (endTouchPosition.y < startTouchPosition.y)
                {
                    Debug.Log("Swipe Down");
                    transform.position = new Vector3(currentPosition.x, currentPosition.y - 2, currentPosition.z);
                    Rotate(180f);
                }
                else if (endTouchPosition.y > startTouchPosition.y)
                {
                    Debug.Log("Swipe Up");
                    transform.position = new Vector3(currentPosition.x, currentPosition.y + 2, currentPosition.z);
                    Rotate(0f);
                }
            }
        } else {
            transform.Translate(speed * Time.deltaTime * Vector2.up);

            if (transform.position.x > wrapBoundaryX || transform.position.x < -wrapBoundaryX) {
                // Reverse the object's position to wrap around the screen
                transform.position = new Vector2(-transform.position.x, transform.position.y);
            }

            if (transform.position.y > wrapBoundaryY || transform.position.y < -wrapBoundaryY) {
                // Reverse the object's position to wrap around the screen
                transform.position = new Vector2(transform.position.x, -transform.position.y);
            }
        }
    }

    

    void Rotate(float angle)
    {
        float currentAngle = transform.rotation.eulerAngles.z;
        if (!Mathf.Approximately(currentAngle, angle)) {
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}
