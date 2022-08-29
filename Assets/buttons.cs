using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour
{

    [SerializeField] GameObject startCanvas;
    [SerializeField] GameObject optionsCanvas;

    Rigidbody2D start;
    Rigidbody2D options;

    [SerializeField] Button playButton;
    [SerializeField] Button optionsButton;
    [SerializeField] Button quitButton;
    [SerializeField] Button backButton;
    [SerializeField] Slider soundSlider;
    [SerializeField] Slider musicSlider;

    public void onPlay()
    {
        playButton.interactable = false;
        optionsButton.interactable = false;
        quitButton.interactable = false;

        //tu bedzie SceneManager...
    }

    public void onOptions()
    {
        playButton.interactable = false;
        optionsButton.interactable = false;
        quitButton.interactable = false;

        start = startCanvas.GetComponent<Rigidbody2D>();
        options = optionsCanvas.GetComponent<Rigidbody2D>();
        StartCoroutine(waiter());

        backButton.interactable = true;
        soundSlider.interactable = true;
        musicSlider.interactable = true;
    }

    public void onQuit()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    public IEnumerator waiter()
    {
        int i;
        for (i = 1; i < 8; i++)
        {
            //Wait for [x] seconds
            yield return new WaitForSeconds((float)0.05*i);

            start.velocity = new Vector2((float)-7 *i*i*i, (float)-3 *i*i*i);
        }
        start.velocity = new Vector2(0, 0);

        for (i = 6; i > 0; i--)
        {
            yield return new WaitForSeconds((float)0.05 * i);

            options.velocity = new Vector2((float)-7 *i*i*i, (float)-3 *i*i*i);
        }
        options.velocity = new Vector2(0, 0);
    }
}
