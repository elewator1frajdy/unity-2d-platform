using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class options : MonoBehaviour
{
    [SerializeField] GameObject startCanvas;
    [SerializeField] GameObject optionsCanvas;

    Rigidbody2D start;
    Rigidbody2D option;

    [SerializeField] Button playButton;
    [SerializeField] Button optionsButton;
    [SerializeField] Button quitButton;
    [SerializeField] Button backButton;
    [SerializeField] Slider soundSlider;
    [SerializeField] Slider musicSlider;

    public void onBack()
    {
        backButton.interactable = false;
        soundSlider.interactable = false;
        musicSlider.interactable = false;

        start = startCanvas.GetComponent<Rigidbody2D>();
        option = optionsCanvas.GetComponent<Rigidbody2D>();
        StartCoroutine(waiter());

        playButton.interactable = true;
        optionsButton.interactable = true;
        quitButton.interactable = true;
    }

    public IEnumerator waiter()
    {
        int i;

        for (i = 0; i < 8; i++)
        {
            yield return new WaitForSeconds((float)0.05 * i);
            option.velocity = new Vector2((float)4.75 * i * i * i, (float)2 * i * i * i);
        }
        option.velocity = new Vector2(0, 0);

        for (i = 6; i > 0; i--)
        {
            //Wait for [x] seconds
            yield return new WaitForSeconds((float)0.05 * i);

            start.velocity = new Vector2((float)10.5 * i * i * i, (float)4.52 * i * i * i);
        }
        start.velocity = new Vector2(0, 0);
    }
}
