using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventario : MonoBehaviour {
    public Inventario it2;
    public string dato;
    public string dato1;
    public int dato2;
    public string nombre;
    public string img;
    public int id;
    public bool guardar = false;
    List<Inventario> Invs;


    public Inventario(string nombre2, string imagen2, int id2)
    {
        nombre = nombre2;
        img = imagen2;
        id = id2;
    }

    void Awake()
    {
        Invs = new List<Inventario>();
    }
   
    void Update()
    {
        instacia(guardar);
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            ver();
            

        }
       
    }
   
        public void instacia(bool guardar)
        {
            if (guardar)
            {
                it2 = new Inventario(dato, dato1, dato2);
                Invs.Add(it2);
            
            }
           


        }
        public void ver()
        {
            foreach (Inventario x in Invs)
            {
           Debug.Log(x.nombre);
           
            }
        }
    
}