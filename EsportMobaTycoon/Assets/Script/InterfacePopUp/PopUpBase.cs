using UnityEngine;

public class PopUpBase : MonoBehaviour, IPopUp
{
    // Le script doit être attacher a un objet qui ne sera pas désactiver sinon le script ne marchera plus donc on désactive la target
    [SerializeField] private GameObject parentWithScript; // Réf au GameObject contenant le script
    private GameObject Target; // Ref à l'objet qui sera SetActive
    

    public GameObject ParentWithScript
    {
        get { return parentWithScript; }
        set { parentWithScript = value; }
    }

    void Start()
    {
        if (ParentWithScript == null)
        {
            Debug.LogError("PopUp canva is not assigned.");
        }
        else
        {
            Target = FindChildWithTag(ParentWithScript, this.GetType().Name);

            if (Target != null)
            {
                Target.SetActive(false);
            }
            else
            {
                Debug.LogWarning($"No child with tag '{this.GetType().Name}' found in {ParentWithScript.name}");
            }
        }
    }

    void Update()
    {
        
    }

    public void Display()
    {
        Target.SetActive(true);
    }

    public void Hide()
    {
        Target.SetActive(false);
    }

    private GameObject FindChildWithTag(GameObject parent, string tag)
    {
        foreach (Transform child in parent.transform)
        {
            if (child.tag == tag)
            {
                return child.gameObject;
            }
        }
        return null;
    }
}
