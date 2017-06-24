using UnityEngine;
using System.Collections;

public class PlayerControllerNEO : MonoBehaviour
{
    public float speed = 6.0F;
    float turnspeed = 50;
    private Vector3 moveDirection = Vector3.zero;
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        transform.Rotate(0, turnspeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0);
        //transform.Rotate(0, 90  * Input.GetAxis("Horizontal"), 0 , 0);

        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            

        controller.Move(moveDirection * Time.deltaTime);
    }
}
