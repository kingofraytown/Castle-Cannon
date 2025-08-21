using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    // Start is called before the first frame update
    //public music audio;
    public music bgm;
    void Start()
    {
        //audio.PlayMusic();
        bgm = GameObject.FindGameObjectWithTag("Music").GetComponent<music>();
        if (!bgm.bgm.IsPlaying())
        {
            bgm.bgm.Play();
        }
        bgm.ChangeMusic(4);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        //change to instructions screen 
        SceneManager.LoadScene("Instructions");
    }

    public void ShowCredits()
    {
        //change to instructions screen 
        SceneManager.LoadScene("Credits");
    }

    public void EndGame()
    {
        //Exit Game
        Application.Quit();
    }
}
