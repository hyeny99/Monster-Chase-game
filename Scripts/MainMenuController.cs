using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
  


    public void PlayGame()
    {

        int selectedPlayer = 
            int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

        Manager.instance.SelectedPlayerIndex = selectedPlayer;

        SceneManager.LoadScene("Gameplay");
    }
}
