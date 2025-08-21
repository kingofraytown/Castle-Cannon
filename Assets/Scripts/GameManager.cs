using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public music bgm;
    void Start()
    {
        bgm = GameObject.FindGameObjectWithTag("Music").GetComponent<music>();
        if (!bgm.bgm.IsPlaying())
        {
            bgm.bgm.Play();
        }
        bgm.ChangeMusic(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowCredits()
    {
        //change to instructions screen 
        SceneManager.LoadScene("CreditsScene");
    }

    public void Replay()
    {
        //change to instructions screen 
        SceneManager.LoadScene("GameScene");
    }
}
