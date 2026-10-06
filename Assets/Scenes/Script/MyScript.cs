using Unity.VisualScripting;
using UnityEngine;

public class MyScript : MonoBehaviour
{
    [SerializeField] int vida;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int _Vida
    {
        get{return vida;}
        set{
            int teste = value;

            vida = teste;
            }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Attacak(){
        
    }
     public void Moviment(){
        
    }
}
