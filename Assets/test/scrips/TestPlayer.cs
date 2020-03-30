using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    public float speed = 5.0f;
    public float SpeedRotation = 200.0f;
    Animator anim;
    public float x, y;
   

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * SpeedRotation, 0);
        transform.Translate(0, 0, y * Time.deltaTime * speed);

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);


        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            anim.SetBool("run", true);
            speed = 6.0f;
        }
        else
        {
            anim.SetBool("run", false);
            speed = 2.0f    ;
        }



        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.Space))
        {
            anim.SetTrigger("run_jump");
           
        }



        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 4, ForceMode.Impulse);
            anim.SetTrigger("PlayerJump");

        }
        

       

        if (Input.GetKey(KeyCode.C))
            anim.SetBool("crouch_idle", true);
        else
            anim.SetBool("crouch_idle", false);

       
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.C))
            anim.SetBool("crouch_walk", true);
        else
            anim.SetBool("crouch_walk", false);

        

    }
}
