using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    public static Manager instance;

    [SerializeField]
    private GameObject[] players;

    private int _selectedPlayerIndex;
    private string _selectedUIBtn;

    public int SelectedPlayerIndex
    {
        get { return _selectedPlayerIndex; }
        set { _selectedPlayerIndex = value; }
    }

    public string SelectedUIBtn
    {
        get { return _selectedUIBtn; }
        set { _selectedUIBtn = value; }
    }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // subscribe to an event
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;

    }

    // unsubscribe from an event
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Gameplay")
        {
            Instantiate(players[SelectedPlayerIndex]);
        }
    }

}
