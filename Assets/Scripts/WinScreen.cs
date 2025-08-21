using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public music bgm;
    // Start is called before the first frame update
    void Start()
    {
        bgm = GameObject.FindGameObjectWithTag("Music").GetComponent<music>();
        bgm.ChangeMusic(1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BackToTitle()
    {
        //change to instructions screen 
        SceneManager.LoadScene("Title");
        bgm.Stop();
    }

    public void PlayGame()
    {
        //change to instructions screen 
        SceneManager.LoadScene("GameScene");
    }

    public void ShowCredits()
    {
        //change to instructions screen 
        SceneManager.LoadScene("Credits");
    }
}
