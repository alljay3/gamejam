using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UiScript : MonoBehaviour
{
    [SerializeField] private string nextLvl;
    public Player GPlayer;
    [SerializeField] GameObject Chapter;
    public void PlayerInputOn()
    {
        GPlayer.inputOn = true;
    }
    public void PlayerInputOff()
    {
        GPlayer.inputOn = false;
    }

    public void ChapterOff()
    {
        Chapter.SetActive(false);
    }

    public void NextLvl()
    {
        SceneManager.LoadScene(nextLvl);
    }
}
