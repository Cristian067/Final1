using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;

public class PlayerControl : MonoBehaviour
{

    public AudioSource audio;

    public Animator animator;



    private float limitx = 10;

    private float limitz = 7.5f;

    public int lifes = 3;

    public int points;

    [SerializeField] private float speed = 8f;

    public TMP_Text text;
    public TMP_Text winLose;

    [SerializeField] private ParticleSystem dead;

    [SerializeField] public ParticleSystem get;

    [SerializeField] public ParticleSystem hurt;


    [SerializeField] public AudioClip coined;
    [SerializeField] public AudioClip hurted;
    [SerializeField] private AudioClip fanfare;

    public bool isGameOver;

    public bool winned;

    private bool died;



    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        isGameOver = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {




        //movimiento
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        transform.Translate(new Vector3(1, 0, 0) * horizontal * speed * Time.deltaTime);
        transform.Translate(new Vector3(0, 0, 1) * vertical * speed * Time.deltaTime);
        //////////////////////////////////////////////////////////////////////////////////////


        //limitar campo
        if(transform.position.x > limitx)
        {
            transform.position = new Vector3(limitx,transform.position.y,transform.position.z);

        }
        if (transform.position.x < -limitx)
        {
            transform.position = new Vector3(-limitx, transform.position.y, transform.position.z);
        }
        if (transform.position.z > limitz) 
        { 
            transform.position = new Vector3(transform.position.x,transform.position.y,limitz); 
        }
        if (transform.position.z < -limitz)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -limitz);
        }
        /////////////////////////////////////////////////////////////////////////////////////////////

        //Game Over
        if (lifes <= 0)
        {

            isGameOver = true;

            lifes = 0;

            //Destroy(gameObject);
            
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////
        

        //Contador de vidas y puntos
        text.text = $"Lifes: {lifes}" +
            $" Points: {points}";
        ///////////////////////////////////////////////////////////////////////////////////

        //Condiciones
        if (isGameOver && !died)
        {
            death();
        }

        if (points >= 50)
        {
            win();
        }
        //////////////////////////////////////////////////////////////////////////////////////////

    }

    private void death()
    {
        died = true;
        dead.Play();
        speed = 0;
        winLose.text = "You Lose";
        
    }

    private void win()
    {
        Debug.Log("You Win");
        speed = 0;
        winned = true;
        winLose.text = "You Win";
    }

    







}
