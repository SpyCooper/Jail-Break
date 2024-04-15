using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManger : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button exitButton;

    [SerializeField] private OptionsMenu optionsMenu;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(() => {
            //Loader.Load(Loader.Scene.GameScene);
        });
        optionsButton.onClick.AddListener(() => {
            optionsMenu.Show();
        });
        exitButton.onClick.AddListener(() => {
            Debug.Log("Exited");
            Application.Quit();
        });
    }
}
