using UnityEngine;
using TMPro;
using UnityEngine.Timeline;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Playables;

public class DialogueBubble : MonoBehaviour
{
    public GameObject i_bubblePrefab;
    
    public Transform i_target; 
    public Vector3 i_offset = new Vector3(0, 2f, 0); 
    public Canvas i_parentCanvas;

    public SignalAsset i_manager1;
    public SignalAsset i_buddy2;
    public SignalAsset i_manager3;
    public SignalAsset i_manager4;
    public SignalAsset i_manager5;
    public SignalAsset i_buddy6;
    public SignalAsset i_manager7;
    public SignalAsset i_buddy8;
    public SignalAsset i_manager9;

    public Button i_buttonNext;

    public TMP_Text i_textButtonNext;
    public PlayableDirector i_playableDirector;

    private Queue<string> i_dialogueQueue = new Queue<string>();

    private bool i_isDialogueActive = false;

    private GameObject i_currentBubble;
    private TypewriterEffect i_currentTypewriter;

    private void Start()
    {
        i_textButtonNext.gameObject.SetActive(false);
        i_buttonNext.gameObject.SetActive(false);
    }

    public void ShowBubble(string message)
    {
        if (i_currentBubble != null)
            Destroy(i_currentBubble);

        i_currentBubble = Instantiate(i_bubblePrefab, i_target.transform);
        i_currentBubble.SetActive(true);

        Button buttonNextDia = i_currentBubble.transform.Find("ButtonNext").GetComponent<Button>();

        if (buttonNextDia != null)
        {
            buttonNextDia.onClick.AddListener(() => OnNextButtonPressed());
        }

        i_currentTypewriter = i_currentBubble.GetComponentInChildren<TypewriterEffect>(true);
        i_currentTypewriter.StartTypewriter(message);

    }

    public void OnSignalReceived(SignalAsset signal)
    {
        if (i_playableDirector != null)
            i_playableDirector.Pause();

        i_dialogueQueue.Clear();

        if (signal == i_manager1)
        {
            i_dialogueQueue.Enqueue("Hé Buddy, t'as deux minutes ? J'ai trouvé un truc de fou.");
        }
        else if (signal == i_buddy2)
        {
            i_dialogueQueue.Enqueue("Tu me laisses même pas commencer mon repas... Mais dis moi tout !");
        }
        else if (signal == i_manager3)
        {
            i_dialogueQueue.Enqueue("Regard, un tournoi d'esport sur notre MOBA préféré. Ca a l'air énorme !");
        }
        else if (signal == i_manager4)
        {
            i_dialogueQueue.Enqueue("Ca pourrait vraiment nous lancer dans le monde de l'esport.");
        }
        else if (signal == i_manager5)
        {
            i_dialogueQueue.Enqueue("Et puis, c'est une super opportunité de se mesurer aux meilleures équipes.");
        }
        else if (signal == i_buddy6)
        {
            i_dialogueQueue.Enqueue("Sérieux ?! Ça a l'air dingue ! On devrait s'inscrire, mais on ne peut y aller juste tous les deux.");
        }
        else if (signal == i_manager7)
        {
            i_dialogueQueue.Enqueue("Oui il nous faut une équipe complète. On doit recruter d'autres joueurs pour être au top.");
        }
        else if (signal == i_buddy8)
        {
            i_dialogueQueue.Enqueue("Bonne idée. On pourrait poster une annonce sur le site de notre campus pour trouver des coéquipiers motivés.");
        }
        else if (signal == i_manager9)
        {
            i_dialogueQueue.Enqueue("Exactement, faisons ça et commençons à nous entraîner sérieusement. On doit être prêts pour le tournoi !");
            i_buttonNext.gameObject.SetActive(true);
            i_textButtonNext.gameObject.SetActive(true);
        }

        if (i_dialogueQueue.Count > 0)
        {
            i_isDialogueActive = true;
            DisplayNextDialogue();
        }
    }

    private void DisplayNextDialogue()
    {
        if (i_dialogueQueue.Count == 0)
        {
            EndDialogue();
            return;
        }

        string nextLine = i_dialogueQueue.Dequeue();
        ShowBubble(nextLine);
    }

    public void OnNextButtonPressed()
    {
        if (!i_isDialogueActive)
            return;

        if (i_currentBubble != null)
            Destroy(i_currentBubble);

        DisplayNextDialogue();
    }

    private void EndDialogue()
    {
        i_isDialogueActive = false;

        if (i_currentBubble != null)
            Destroy(i_currentBubble);

        if (i_playableDirector != null)
            i_playableDirector.Play();
    }

    void Update()
    {
        if (i_currentBubble != null && i_target != null)
        {
            Vector3 worldPosition = i_target.position + i_offset;

            Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);

            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                i_parentCanvas.transform as RectTransform,
                screenPosition,
                i_parentCanvas.worldCamera,
                out Vector2 localPoint
            );
            i_currentBubble.GetComponent<RectTransform>().localPosition = localPoint;
        }
    }

}
