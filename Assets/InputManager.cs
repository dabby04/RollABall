using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent<Vector2> OnMove = new UnityEvent<Vector2>();
    public UnityEvent OnJump = new UnityEvent();

    // Update is called once per frame
    void Update()
    {
       Vector2 inputVector = Vector2.zero; //initialising our input vector
        if(Input.GetKey(KeyCode.W))
        {
            Debug.Log("User's Input: up");
            inputVector += Vector2.up;
        }
         if(Input.GetKey(KeyCode.A))
        {
            Debug.Log("User's Input: left");
            inputVector+=Vector2.left;
        }
         if(Input.GetKey(KeyCode.S))
        {
            Debug.Log("User's Input: down");
            inputVector+=Vector2.down;
        }
         if(Input.GetKey(KeyCode.D))
        {
            Debug.Log("User's Input: right");
            inputVector+=Vector2.right;
        } 

        OnMove?.Invoke(inputVector);

         
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Ball bounced!");
            OnJump.Invoke();
        }
        
    }
}
