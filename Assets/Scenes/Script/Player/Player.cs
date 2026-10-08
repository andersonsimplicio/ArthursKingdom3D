using System;
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
    [SerializeField] Animator animator;
    [SerializeField] bool isAttack;
    [SerializeField] private float attackCoolDown = 0.53f;
    const float timeAttack1 =  0.53f;
    private static readonly int speedHash = Animator.StringToHash("Speed");
    private static readonly int attackHash = Animator.StringToHash("Attack");
    private Vector3 inputDirection;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movimentSpeed = 3.0f;
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       Move();
       Attack();
       UpdateAttackState(); 
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
            if (inputDirection!=Vector3.zero && isAttack==false)
            {
                Quaternion targetRotation = Quaternion.LookRotation(inputDirection);
                transform.rotation= Quaternion.Slerp(transform.rotation,targetRotation,rotationSpeed*Time.deltaTime);
                controller.Move(inputDirection * movimentSpeed * Time.deltaTime);
            }
        }
        animator.SetFloat(speedHash,inputDirection.magnitude);
    }
    private void Attack()
    {
        if (Input.GetMouseButton(0) && isAttack==false)
        {
            animator.SetTrigger(attackHash);
            isAttack=true;
            attackCoolDown = timeAttack1;
        }
    }
    private void UpdateAttackState()
    {
     
        if (isAttack==true)
        {
            attackCoolDown-=Time.deltaTime;
            if (attackCoolDown <= 0)
            {
                isAttack=false;
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
