
using UnityEngine;
using System.Collections;



public class MetodosItem : MonoBehaviour
{
    public Collider colider;
    public string mensaje = "Pulsa E para cogerlo";
    private string mensaje2;
    public bool activo = false;
    public GUIStyle font;
    public bool destruido = false;
    public bool recogido = false;
    public GameObject aux;
    private Inventario inv;
     public string nombre;
    public string img;
    public int id;


    void Awake()
    {

        colider = GetComponent<Collider>();
        aux = GameObject.FindGameObjectWithTag("Player");
        inv =aux.GetComponent<Inventario>();
      





}
    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.E))
        {

            colider.isTrigger = true;
           






        }
        else
        {

            colider.isTrigger = false;

        }


    }
    void OnGUI()
    {

        if (activo)
        {

            font.fontSize = 50;
            font.normal.textColor = Color.red;
            GUI.Label(new Rect(Screen.width / 2 - 200, 300, 200, 500), mensaje2, font);
            GUI.Label(new Rect(Screen.width / 2 - 200, 50, 200, 30), mensaje, font);
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (inv.esguardar)
            {
                recogido = true;
                inv.guardar = recogido;
                inv.dato = nombre;
                inv.dato1 = img;
                inv.dato2 = id;
                inv.dato3 = 1;
                Destroy(gameObject);
            }
            else
            {
                 mensaje2 = "Inventario lleno";
            }

        }
      


    }



    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            mensaje = "Pulsa E para cogerlo";
            activo = true;
        }



    }
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            activo = false;
        }
    }
    

}
 
    

    
    
        

    
    



