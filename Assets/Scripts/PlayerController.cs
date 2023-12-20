using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float velocityMove;
    [SerializeField] float velocityRotation;
    [SerializeField]Animator anim;
    [SerializeField]Rigidbody rb;
    Vector3 positionAvance;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (x != 0 || y != 0)
        {
            // Calcula la dirección global basada en la dirección local del personaje
            Vector3 direction = new Vector3(x, 0, y).normalized;
            Vector3 globalDirection = transform.TransformDirection(direction);

            // Calcula la rotación hacia la nueva dirección
            Quaternion newRotation = Quaternion.LookRotation(globalDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * velocityRotation);

            // Aplica el movimiento hacia la nueva dirección
            positionAvance = globalDirection * velocityMove;
        }
        else
        {
            positionAvance = Vector3.zero;
        }
        anim.SetFloat("VelX",x);
        anim.SetFloat("VelY",y);
    }
    private void FixedUpdate() {
        rb.velocity = new Vector3(positionAvance.x,rb.velocity.y,positionAvance.z);
         //positionAvance;
    }

}
