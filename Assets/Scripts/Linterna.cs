using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
public class Linterna : MonoBehaviour
{
    public float bateria=100;
    [SerializeField,Tooltip("el radio de la linterza, spherecast")]private int radio;
    [SerializeField,Tooltip("Enemigos que estan en colicion con la linterna")] private List<GameObject> enemigosEnEscena;
    [SerializeField,Tooltip("luz de la linterna")] Light luzLinterna;

    public void ActivarDesactivar()
  {
        //desactivar solo la luz para poder seguir controlando este script
        luzLinterna.enabled = luzLinterna.enabled ? false : true;
        //agregar aqui sonido de apagado o encendido
  }
    //Controlar los enemigos  que estan en el rango de la linterna
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            print($"enemigo {other.name} colicionado,agregado a la lista");
            enemigosEnEscena.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemigo")  && enemigosEnEscena.Contains(other.gameObject) )
        {
            print("sale el enemigo de la lista");
            enemigosEnEscena.Remove(other.gameObject);  
        }
    }
}