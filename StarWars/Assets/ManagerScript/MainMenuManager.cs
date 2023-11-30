using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNewGame() {
        SceneManager.LoadScene("TutorialLevelScene");
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void Logout() {
        // log the user out of firebase
        Firebase.Auth.FirebaseAuth.DefaultInstance.SignOut();

        SceneManager.LoadScene("TitleScreen");
    }
}
