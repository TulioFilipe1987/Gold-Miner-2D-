using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookMovement : MonoBehaviour
{

    public float min_Z = -55f, max_Z = 55f;
    public float rotate_Speed = 5f;

    private float rotate_Angle;
    private bool rotate_Right;
    private bool canRotate;

    public float move_Speed = 3f;
    private float initial_Move_Speed;

    public float min_Y = -2.5f;
    private float initial_Y;

    private bool moveDown;

    
    //FOR LINE RENDERER
    private RopeRenderer ropeRendeder;  // call the script RopeRenderer

    void Awake()
    {
        ropeRendeder = GetComponent<RopeRenderer>();
    }

    void Start()
    {
        initial_Y = transform.position.y;  //  THE VALUE OF initial_Y
        initial_Move_Speed = move_Speed;

        canRotate = true;




        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        GetInput();
        MoveRope();
    }

    void Rotate()
    {
        if (!canRotate)
            return;

        if (rotate_Right){
            rotate_Angle += rotate_Speed * Time.deltaTime;
        }else{  //rotate_Left   SIDE LEFT
            rotate_Angle -= rotate_Speed * Time.deltaTime;
        }

        transform.rotation = Quaternion.AngleAxis(rotate_Angle,Vector3.forward);
    
        if(rotate_Angle >= max_Z){

            rotate_Right = false;

        }else if(rotate_Angle <= min_Z){  // SIDE LEFT
          
            rotate_Right = true;
        }
    
    }// can rotate "ALONE"

    void GetInput()
    {
        if (Input.GetMouseButtonDown(0)){

            if (canRotate){
                canRotate = false;
                moveDown = true;

            }

        }
    }// get input


    void MoveRope(){

        if (canRotate)
            return;

        if (!canRotate){

            //Soundmanager.instance.ropeStretch(true);
            Vector3 temp = transform.position;

            if (moveDown)  {

             temp -= transform.up * Time.deltaTime * move_Speed;

                //temp.y -= Time.deltaTime * move_Speed; //wrong

            }
            else {

               temp += transform.up * Time.deltaTime * move_Speed;

                //temp.y += Time.deltaTime * move_Speed; // wrong

            }


            transform.position = temp;


            if(temp.y <= min_Y){ // Y = -2.5f

                moveDown = false; 
            }

            if(temp.y >= initial_Y){

                canRotate = true;

                // deactivate line renderer
                ropeRendeder.RenderLine(temp,false);// actived 2 ; fuction renderline

                // reset move speed
                move_Speed = initial_Move_Speed;

                //soundManager.instance.ropeStrech(false);
            
            }

            ropeRendeder.RenderLine(transform.position,true); // actived 1. take fuction "renderline"

        }// cannot rotate

    }// move rope


}//class
