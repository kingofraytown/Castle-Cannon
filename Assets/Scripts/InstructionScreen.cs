using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionScreen : MonoBehaviour
{
    public music bgm;
    // Start is called before the first frame update
    void Start()
    {
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

    public void PlayGame()
    {
        //change to instructions screen 
        SceneManager.LoadScene("GameScene");
    }
}
