using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
   
   public void changeScene(string _sceneName)
   {
        
       
        SceneManager.LoadScene(1);
    



   }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();



    }
}