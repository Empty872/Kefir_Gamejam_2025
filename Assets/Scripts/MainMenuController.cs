using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuCOntroller : MonoBehaviour
{
    [SerializeField] private Button gameButton;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("TutorialCompleted") && PlayerPrefs.GetInt("TutorialCompleted") == 1)
        {
            gameButton.gameObject.SetActive(true);
        }
        else
        {
            gameButton.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}