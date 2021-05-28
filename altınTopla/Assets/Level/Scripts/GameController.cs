using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject yenidenButonu;
    public GameObject cikisButonu;

    public GameObject wall;
    List<GameObject> currentWalls = new List<GameObject>();

    void Start()
    {
        Random.InitState((int)System.DateTime.Now.Ticks); //her başladdığında farklı değer 
        NextLevel();
    }

    public void tekrarOyna(){
        yenidenButonu.gameObject.SetActive (true);
        SceneManager.LoadScene("Level");
    }
    public void bitir(){
        cikisButonu.gameObject.SetActive (true);
        Application.Quit();
    }
    public void yeniOyun(){
        SceneManager.LoadScene("Main");
    }

  


    public void NextLevel() 
    {
        // son seviyedeki herhangi bir öğeyi silmek için 
        foreach(GameObject wall in currentWalls)
        {
            Destroy(wall);
        }

        float[] xLocations = { -6, 0, 6 };
        float[] zLocations = { -14, 0, 14};

        // her döngüde bir duvarı olmayan yeri tespit etmek için
        int blankIndex = -1;
        

        for(int i = 0; i< 3; i++)
        {
            //Rastgele konumlu duvarlar için
            int zIndex1 = blankIndex > -1 ? blankIndex : Random.Range(0, zLocations.Length); 
            int zIndex2 = Random.Range(0, zLocations.Length);

            while(zIndex1 == zIndex2)
            {
                zIndex2 = Random.Range(0, zLocations.Length);
            }

            Vector3 location = new Vector3(xLocations[i], 1, zLocations[zIndex1]);

            currentWalls.Add(Instantiate(wall, location, Quaternion.Euler(0, 0, 0))); //çoğaltma

            location = new Vector3(xLocations[i], 1, zLocations[zIndex2]);

            currentWalls.Add(Instantiate(wall, location, Quaternion.Euler(0, 90, 0)));//çoğaltma
            currentWalls[currentWalls.Count - 1].transform.localScale += new Vector3(-0.001f, -0.001f, -0.001f);
            
            blankIndex = 0;

            if(blankIndex == zIndex1 || blankIndex == zIndex2)
            {
                blankIndex = 1;
            }
            if (blankIndex == zIndex1 || blankIndex == zIndex2)
            {
                blankIndex = 2;
            }
        }
        
    }
    
}
