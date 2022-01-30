using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Koffie.SimpleTasks;

public class UIController : MonoBehaviour
{
    // Variables
    [SerializeField] private GameObject BackgroundMenu;
    [SerializeField] private GameObject Message;
    [SerializeField] private GameObject Fader;
    [SerializeField] private GameObject DialogueBox;
    [SerializeField] private TextMeshProUGUI DialogueText;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showStartMessage()
    {
        Message.SetActive(true);
        TextMeshProUGUI txt = Message.GetComponent<TextMeshProUGUI>();
        txt.text = ("Press Enter to Start");
    }

    public void showRetryMessage()
    {
        Message.SetActive(true);
        TextMeshProUGUI txt = Message.GetComponent<TextMeshProUGUI>();
        txt.text = ("Press Enter to Retry");
    }

    public void disableMessage()
    {
        Message.SetActive(false);
    }

    public void playFade()
    {
        Fader.GetComponent<Animator>().SetTrigger("Start");
    }

    public void enableBackgroundMenu()
    {
        BackgroundMenu.SetActive(true);
    }

    public void disableBackgroundMenu()
    {
        BackgroundMenu.SetActive(false);
    }

    public void showDialogueBox(string str)
    {
        DialogueBox.SetActive(true);
        DialogueText.text = "";
        STasks.Do(() => DialogueText.text=str, after: 0.5f);
    }

    public void disableDialogueBox()
    {
        DialogueBox.SetActive(false);
    }
}
