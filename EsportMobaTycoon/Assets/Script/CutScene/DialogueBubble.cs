using UnityEngine;
using TMPro;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class DialogueBubble : MonoBehaviour
{
    public GameObject i_bubblePrefab; 
    public Transform i_target; 
    public Vector3 i_offset = new Vector3(0, 2f, 0); 
    public Canvas i_parentCanvas;

    private GameObject i_currentBubble;
    private TypewriterEffect i_currentTypewriter;
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

    public void ShowBubble(string message, float duration = 2f)
    {

        i_currentBubble = Instantiate(i_bubblePrefab, i_target.transform);
        i_currentBubble.SetActive(true);

        i_currentTypewriter = i_currentBubble.GetComponentInChildren<TypewriterEffect>(true);

        i_currentTypewriter.StartTypewriter(message);

        Destroy(i_currentBubble, duration); 
    }

    public void OnSignalReceived(SignalAsset signal)
    {
        if (signal == i_manager1)
        {
            ShowBubble("Hé Buddy, t'as deux minutes ? J'ai trouvé un truc de fou.", 6);
            Update();
        }
        else if (signal == i_buddy2)
        {
            ShowBubble("Tu me laisses même pas commencer mon repas... Mais dis moi tout !", 6);
            Update();
        }
        else if (signal == i_manager3)
        {
            ShowBubble("Regard, un tournoi d'esport sur notre MOBA préféré. Ca a l'air énorme !", 6);
            Update();
        }
        else if (signal == i_manager4)
        {
            ShowBubble("Ca pourrait vraiment nous lancer dans le monde de l'esport.", 6);
            Update();
        }
        else if (signal == i_manager5)
        {
            ShowBubble("Et puis, c'est une super opportunité de se mesurer aux meilleures équipes.", 6);
            Update();
        }
        else if (signal == i_buddy6)
        {
            ShowBubble("Serieux ?! Ca a l'air dingue ! On devrait s'inscire, mais on ne peut y aller juste tous les deux.", 6);
            Update();
        }
        else if (signal == i_manager7)
        {
            ShowBubble("Oui il nous faut une équipe complète. On doit recruter d'autres joueurs pour être au top.", 6);
            Update();
        }
        else if (signal == i_buddy8)
        {
            ShowBubble("Bonne idée. On pourrait poster une annonce sur le site de notre campus pour trouver des coéquipiers motivés.", 6);
            Update();
        }
        else if (signal == i_manager9)
        {
            ShowBubble("Exactement, faisons ça et commencons à nous entraîner sérieusement. On doit être prêts pour le tournoi !", 6);
            Update();
            i_buttonNext.gameObject.SetActive(true);
            i_textButtonNext.gameObject.SetActive(true);
        }
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
