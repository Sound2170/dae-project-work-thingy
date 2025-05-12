using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControlller : MonoBehaviour
{
   [SerializeField] private string TestRoom = "gameScene";

   public void OnStartPressed() 
   {
    SceneManager.LoadScene(TestRoom);
   }

   public void OnOptionsPressed()
   {
    //setting it up for later
   }

   public void OnQuitPressed()
   {
    #if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false; 
    #else 
    Application.Quit();
    #endif
   }
}
