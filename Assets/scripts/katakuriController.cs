using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class katakuriController : MonoBehaviour
{
    private const int ANIMATION_QUIETO = 0;
    private const int ANIMATION_LANZA = 1;
    private const int ANIMATION_PISOTON = 2;
    private const int ANIMATION_ATTACKDISTANCIA= 3;
    private const int ANIMATION_PUÑO = 4;

    private const int ANIMATION_RAFAGA_PUÑO=5;
    private const int ANIMATION_PUÑO_3MARCHA=6;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool estaSaltando=false;
    private bool estagolpeando=false;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
 
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.R)  )
                {
                    rb.velocity = Vector2.up * 5;
                    
                    //StartCoroutine("Esperar");
                    CambiarAnimacion(ANIMATION_PISOTON);
                    estaSaltando=true;
                 
                }
                else if(Input.GetKey(KeyCode.T))
                {   
                    
                    CambiarAnimacion(ANIMATION_PUÑO);
                    StartCoroutine("Esperar");
                    rb.velocity = Vector2.right*3;
            
                     
                    
                }else if(Input.GetKey(KeyCode.G))
                {
                    rb.velocity = Vector2.right*3;
                    StartCoroutine("Esperar");
                    CambiarAnimacion(ANIMATION_LANZA);
                }else if(Input.GetKey(KeyCode.H))
                {
                     estagolpeando=true;
                    StartCoroutine("Esperar");
                    CambiarAnimacion(ANIMATION_RAFAGA_PUÑO);
                }else if(estaSaltando==false&&estagolpeando==false)
                {
                    //Esperar();
                    CambiarAnimacion(ANIMATION_QUIETO);
                    rb.velocity = new Vector2(0, rb.velocity.y);
                }
    }
   
    IEnumerator Esperar(){
        yield return new WaitForSecondsRealtime((3/2));
    }
 
    void OnCollisionEnter2D(Collision2D other)
    {
        estaSaltando=false;
    }
    private void CambiarAnimacion(int animacion)
    {
        animator.SetInteger("Estado", animacion);
    }
}
