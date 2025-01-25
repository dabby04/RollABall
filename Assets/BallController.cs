using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Rigidbody sphereRigidBody;
    [SerializeField] float ballSpeed;
    [SerializeField] float jumpForce;

     private bool isGrounded;
   
    private void OnCollisionEnter(Collision other)
    { //checking that when the ball enters, it is on the ground
        if(other.gameObject.CompareTag("Ground")){
            Vector3 normal=other.GetContact(0).normal;
            if(normal==Vector3.up){ //checking that when it hits an obstacle, it cannot double jump
                isGrounded=true;
            } 
        }
    }

    private void OnCollisionExit(Collision other)
    { //when the ball is off the ground, set the value to false
        if(other.gameObject.CompareTag("Ground")){
            isGrounded=false; 
        }
    }
       public void MoveBall(Vector2 input)
    {
        Vector3 inputXZPlane = new(input.x,0,input.y);
        sphereRigidBody.AddForce(inputXZPlane * ballSpeed);
    }

    public void BounceBall()
    { //when the space key is pressed, the ball should bounce
       if (isGrounded)
        {
            sphereRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }


}
