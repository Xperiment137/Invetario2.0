using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class Inventario : MonoBehaviour {
    public string dato;
    public string dato1;
    public int dato2;
    public int dato3;
    public string nombre;
    public string img;
    public int id;
    public int cantidad;
    public bool guardar = false;
    public bool esguardar = false;
    private bool activo = false;
    public GUIStyle font;
    public string mensaje = "No puedo borrar algo que no existe";
    public Text tex1;
    public Text tex2;
    public Text tex3;
    public Text tex4;
    public Text tex5;
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
        
        if (Invs.Count < 5)
        {
            esguardar = true;
            if (guardar)
            {

                instacia();
                guardar = false;

            }
        }
        else
        {
            esguardar = false;
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
    public void Borrar(int identidad)
    {
        if (Invs.Exists(x => x.id == identidad))
        {
            Invs.RemoveAt(Invs.FindIndex(x => x.id == identidad));
        }
        else
        {
            activo = true;
          
        }
        
    }
    public void Mostar()
    {
    
        tex1.text = Invs[0].name;
        tex2.text = Invs[1].name;
        tex3.text = Invs[2].name;
        tex4.text = Invs[3].name;
        tex5.text = Invs[4].name;

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
    void OnGUI()
    {

        if (activo)
        {



            GUI.Label(new Rect(Screen.width / 2 - 100, 100, 200, 50), mensaje, font);
        }

    }

}