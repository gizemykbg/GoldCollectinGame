using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    void Start()
    {
        ChangeColor();
    }

    public void ChangeColor() 
    {
        // Renk değiştir
        Color[] options = { Color.gray, Color.green, Color.magenta, Color.yellow, Color.blue};
        Color newColor = options[Random.Range(0, options.Length)];
        gameObject.GetComponent<Renderer>().material.color = newColor;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            ChangeColor();
        }
    }
}
