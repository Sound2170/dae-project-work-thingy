using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControlller : MonoBehaviour
{
   [SerializeField] private string TestRoom = "gameScene";
   [SerializeField] private GameObject optionsPanel;


   public void OnStartPressed() 
   {
    SceneManager.LoadScene(TestRoom);
   }

   public void OnOptionsPressed()
   {
      optionsPanel.SetActive(true);
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
