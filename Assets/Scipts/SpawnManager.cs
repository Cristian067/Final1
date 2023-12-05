using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    private int random;
    private int randomposx;
    private int randomposz;

    [SerializeField] private GameObject[] coins;

    private float limitx = 10;

    private float limitz = 7.5f;


    private PlayerControl player;

    // Start is called before the first frame update
    void Start()
    {
        //Empezar a generar monedas
        InvokeRepeating("spawn", 1, 1.7f);
        ///////////////////////////////////////////////
        

        //Localizar el script del jugador
        player = FindFirstObjectByType<PlayerControl>();
        ///////////////////////////////////////////////////

    }

    // Update is called once per frame
    void Update()
    {
        //Generar numeros aleatorios para las monedas y las posiciones donde se generan
        random = Random.Range(0, coins.Length);
        randomposx = Random.Range(-8, 8);
        randomposz = Random.Range(-6, 6);
        /////////////////////////////////////////////////////////////////////////
        

        //El parar de generar monedas cuando el jugador gane o pierda la partida
        if (player.isGameOver || player.winned)
        {
            CancelInvoke("spawn");
        }

        //////////////////////////////////////////////////////////////////////////////
        
        
    }

    
    
    //funcion para generar las monedas aleatoriamente y en posiciones aleatorias por el generador de numeros aleatorios
    private void spawn()
    {
        Instantiate(coins[random], new Vector3(randomposx,0,randomposz), Quaternion.identity);

    }


}
