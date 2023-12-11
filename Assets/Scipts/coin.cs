using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{


    [SerializeField] private int coinV;



    private PlayerControl player;

    [SerializeField] private float speed = 5;

    [SerializeField] private bool life;

    //[SerializeField] private ParticleSystem get;


    // Start is called before the first frame update
    void Start()
    {
        //Al pasar tres segundos ejecuta una funcion, que esa funcion es para que se destruya
        Invoke("die",3);
        /////////////////////////////////////////////////////////////////////////////////////
        
        //Localiza al jugador
        player = FindAnyObjectByType<PlayerControl>();
        ///////////////////////////////////////////////////////

    }

    // Update is called once per frame
    void Update()
    {
        
        //Si la moneda es mala perseguira al jugador para matarlo
        if(gameObject.tag == "Bad Coin")
        {

            transform.LookAt(player.transform.position);
            transform.Translate(new Vector3(0,0,1) * Time.deltaTime * speed);
        }
        ///////////////////////////////////////////////////////////////////////////////


    }

    //Funcion para que se destruya la moneda
    private void die()
    {
        Destroy(gameObject);
    }


    //////////////////////////////////////////////
    
    /// <summary>

    /// </summary>
    /// <param //name="other"></param>


    private void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Player")
        {

            //Condiciones de si la moneda es buena hace una cosa al jugador y si es mala hace otra cosa

            if (gameObject.tag == "Bad Coin")
            {
                player.lifes--;
                player.hurt.Play();
                player.animator.SetTrigger("hurt");
                player.audio.PlayOneShot(player.hurted);
                Destroy(gameObject);
            }

            if(gameObject.tag =="Good Coin")
            {
                if(life)
                {
                    player.lifes++;
                }

                player.points += coinV;

                player.get.Play();
                player.audio.PlayOneShot(player.coined);
                
                Destroy(gameObject);

            }
            ///////////////////////////////////////////////////////////////////////////////////////

        }
    }

    



}
