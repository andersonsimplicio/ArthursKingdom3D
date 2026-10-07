using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float movimentSpeed;
    [SerializeField] float rotationSpeed = 10f;
    [SerializeField] float gravity=-9.8f;
    [SerializeField] float jump=1.2f;
    [SerializeField] bool isJump;
    [SerializeField] CharacterController controller;
    private Vector3 inputDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movimentSpeed = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
       Move();

    }

    public float _movimentSpeed
    {
        get{return movimentSpeed;}
        set{movimentSpeed = value;}
    }

    
    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        inputDirection = new Vector3(horizontal,0f,vertical);
        

        if (controller != null)
        {
            if (inputDirection!=Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(inputDirection);
                transform.rotation= Quaternion.Slerp(transform.rotation,targetRotation,rotationSpeed*Time.deltaTime);
                controller.Move(inputDirection * movimentSpeed * Time.deltaTime);
            }
        }

    }



    //move o personagem
        void _move()
        {
        var keyboard =Keyboard.current; 
        if(keyboard==null) return;

        
            if(keyboard.spaceKey.wasPressedThisFrame && !isJump)
            {
                inputDirection.y= Mathf.Sqrt(jump*-2f*gravity);
                isJump=true;
            }
            Vector2 input = Vector2.zero;
            
            if(keyboard.wKey.isPressed) input.y+=1f; 
            if(keyboard.sKey.isPressed) input.y-=1f; 
            if(keyboard.aKey.isPressed) input.x-=1f; 
            if(keyboard.dKey.isPressed) input.x+=1f; 
            
            input = input.normalized;
            Vector3 move = transform.rotation *new Vector3(input.x,0f,input.y);
            inputDirection.y +=gravity*Time.deltaTime;
            Vector3 finalMoviment = (move*movimentSpeed)+inputDirection;
            
            CollisionFlags flags =  controller.Move(finalMoviment * Time.deltaTime);

            if ((flags & CollisionFlags.Below)!=0)
            {
                inputDirection.y=-2f;
                isJump=false;
            }
            }
    } 
