using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class Inventario : MonoBehaviour {
    public Inventario it2;
    public string dato;
    public string dato1;
    public int dato2;
    public int dato3;
    public string nombre;
    public string img;
    public int id;
    public int cantidad;
    public bool guardar = false;
    private int contador = 0;
    List<Inventario> Invs= new List<Inventario>(5);
    public GameObject aux;
   
    
    void Awake()
    {
         
        aux = GameObject.Find("pausePanel");
        
    }
    void Start()
    {
        aux.SetActive(false);
        
    }

    void Update()
    {
      
            if (guardar)
            {

                instacia();
                guardar = false;

            }
        
       
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (aux.activeSelf)
            {

                ContinueGame();


            }
            else
            {


                PauseGame();
                ver();
                Debug.Log(Invs.Count);


            }
        }
    
    }

     
            
     
        public void instacia()
        {
        if (Invs.Exists(x => x.id == dato2))
        {
            Invs[Invs.FindIndex(x => x.id == dato2)].cantidad++;
        }
        else
        {
            Invs.Add(new Inventario() { nombre = dato, img = dato1, id = dato2, cantidad = dato3 });
        }

        if (Invs.Count == 2)
        {

            Debug.Log("Inventario lleno");
        }

    

        }
    public void ver()
    {
        foreach (Inventario x in Invs)
        {
            Debug.Log(x.nombre);
            Debug.Log(x.img);
            Debug.Log(x.id);
            Debug.Log(x.cantidad);

        }
    }
    
  
        private void PauseGame()
        {
            Time.timeScale = 0;
          aux.SetActive(true);
           
        }

        private void ContinueGame()
        {
            Time.timeScale = 1;
            aux.SetActive(false);
            
        }
    
}