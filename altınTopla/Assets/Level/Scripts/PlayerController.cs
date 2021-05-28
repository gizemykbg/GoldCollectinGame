using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public Rigidbody rigid;
    public float Force = 45.0f; //hız
    public CameraController mainCamera;
    private int level = 1;
    public Text levelText;
    public Text zaman;
    public Text canText;
    float canSayaci= 3;
    float zamanSayaci=50;
    public static bool gameOver;
    public GameObject gameOverPanel;
    public static bool gameStarted;
    public GameObject startingText;


    public GameController gameController;

  void Start()
    {
        Time.timeScale = 1;
        gameOver = false;
        gameStarted = false;
    }

    void Update()
    {
         if(level == 3){
            gameController.yeniOyun();
        }
         if(Input.GetKey("up") && !gameStarted)
         {
             gameStarted = true;
             Destroy(startingText);
        }
        if(gameStarted)
       {
        zamanSayaci -= Time.deltaTime;
        zaman.text = (int)zamanSayaci+"";
        }
         if (gameOver)
        {
            gameOverPanel.SetActive(true);
            zamanSayaci = 0;
             Destroy(startingText);
        }
        if (zamanSayaci < 0 ){
            // gameOverPanel.SetActive(true);
             gameOver = true;
              Destroy(startingText);
        }
//forcemode kullanarak kuvvet vektörümüzü nasıl uygulayacağımızı seçtik
        if (Input.GetKey("up") || Input.GetKey("w"))
        {
            rigid.AddForce(0, 0, Force * Time.deltaTime, ForceMode.VelocityChange);
            mainCamera.SetDirection("up");
        }
        if (Input.GetKey("down") || Input.GetKey("s"))
        {
            rigid.AddForce(0, 0, -Force * Time.deltaTime, ForceMode.VelocityChange);
            mainCamera.SetDirection("down");
        }
        if (Input.GetKey("right") || Input.GetKey("d"))
        {
            // Rigidbody üzerinde bir Hız değişikliği yapıyoruz
            rigid.AddForce(Force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            mainCamera.SetDirection("right");
        }
        if (Input.GetKey("left") || Input.GetKey("a"))
        {
            rigid.AddForce(-Force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            mainCamera.SetDirection("left");
        }
    }


    private void OnTriggerEnter(Collider collider) //exit panele çarptığında level+1 ve hız +2 artsın
    {
        
        if (collider.tag == "Exit")
        {
            PlayerYeniden();
            level = level + 1;
            Force += 2.0f;
            gameController.NextLevel();
        }
        levelText.text = level.ToString();
    }

    private void OnCollisionEnter(Collision collision) // duvara vurduğunda 
    {
        if (collision.gameObject.tag == "wall")
        {
            // zemin ground rengi vurdukça diziden random
            Color[] options = { Color.white, Color.black, Color.magenta };
            Color newColor = options[Random.Range(0, options.Length)];
            GameObject.Find("Ground").GetComponent<Renderer>().material.color = newColor;
            //level = 1;
            Force = 25.0f; //yavaşlasın
            canSayaci -= 1;
            canText.text = canSayaci.ToString();
            if(canSayaci == 0){
                gameOverPanel.SetActive(true);
                gameOver = true;
               PlayerYeniden();
                level = 1;
            }
        } 
        levelText.text = level.ToString();
    }

    void PlayerYeniden() // oyuncunun pozisyonunu yakala ve güncelle
    {
        if (level <= 3){ 
              zamanSayaci -= Time.deltaTime;
        zaman.text = (int)zamanSayaci+"";
        transform.position = new Vector3(15.0f, 1.3f, -15.0f); //player başlangıç konumum
        transform.rotation = Quaternion.Euler(-90, 0, 90); //player açılarım
        }
       
    }
   
    }

