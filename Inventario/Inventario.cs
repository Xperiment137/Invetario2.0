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
    public Text tex,tex1,tex2,tex3,tex4;
    public Button boton, boton1, boton2, boton3, boton4;
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
                Cursor.visible = false;
                activo = false;
            }
            else
            {


                PauseGame();
                Mostar();
                pulsador();
                Cursor.visible = true;


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
      
           
            Invs.RemoveAt(Invs.FindIndex(x => x.id == identidad));
           
        
        
           
        
    }
    public void Mostar()
    {
        int i;

        if (Invs.Count > 0)
        {

            for (i = 0; i < Invs.Count; i++)
            {
                if (Invs.Contains(Invs[i]))
                {
                    
                    switch (i)
                    {
                        case 0:
                            tex.text = Invs[i].nombre;
                            break;
                        case 1:
                            tex1.text = Invs[i].nombre;
                            break;
                        case 2:
                            tex2.text = Invs[i].nombre;
                            break;
                        case 3:
                            tex3.text = Invs[i].nombre;
                            break;
                        case 4:
                            tex4.text = Invs[i].nombre;
                            break;
                        default:

                            break;

                    }

                }

            }
        }
        else
        {
            tex.text = "Vacio";
            tex1.text = "Vacio";
            tex2.text = "Vacio";
            tex3.text = "Vacio";
            tex4.text = "Vacio";
        }
    }
 
        private void botones(int j)
    {
 
        if(j<Invs.Count)
        {
        
                switch (j)
                {
                    case 0:
                    Borrar(Invs[j].id);
                    tex.text = "Vacio";
                    break;
                    case 1:
                    Borrar(Invs[j].id);
                    tex1.text = "Vacio";
                    break;
                    case 2:
                    Borrar(Invs[j].id);
                    tex2.text = "Vacio";
                    break;
                    case 3:
                     Borrar(Invs[j].id);
                    tex3.text = "Vacio";
                    break;
                    case 4:
                    Borrar(Invs[j].id);
                    tex4.text = "Vacio"; ;
                    break;
                    default:
                    activo = true;
                    break;


                }
            
        }
        else
        {
            activo = true;
        }
   }
     private void pulsador()
    {
        
        boton.onClick.AddListener(() => botones(0));
        boton1.onClick.AddListener(() => botones(1));
        boton2.onClick.AddListener(() => botones(2));
        boton3.onClick.AddListener(() => botones(3));
        boton4.onClick.AddListener(() => botones(4));
       
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