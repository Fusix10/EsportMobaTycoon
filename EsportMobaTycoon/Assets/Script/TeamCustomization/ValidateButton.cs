using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class ValidateButton : MonoBehaviour
{
    [SerializeField] private TeamData teamData;
    [SerializeField] private List<UnputFieldGrabber> inputFieldGrabberList;
    [SerializeField] private List<SkinCarouselle> CarouselleList;


    [SerializeField] TMP_Text nameField;
    [SerializeField] TMP_Text lastNameField;

    [SerializeField] SkinCarouselle hair;
    [SerializeField] SkinCarouselle face;
    [SerializeField] SkinCarouselle torso;
    [SerializeField] SkinCarouselle legs;


    [SerializeField] Image male;
    [SerializeField] Image female;
    [SerializeField] Sprite maleSelect;
    [SerializeField] Sprite femaleSelect;
    [SerializeField] Sprite maleUnselect;
    [SerializeField] Sprite femaleUnselect;
    [SerializeField] private bool isGenderMale;



    void Awake()
    {
        if (teamData == null)
            Debug.LogError("TeamData n'est pas assigné !");
        if (inputFieldGrabberList == null || inputFieldGrabberList.Count < 2)
            Debug.LogError("Il faut 2 UnputFieldGrabber dans inputFieldGrabberList !");
        if (CarouselleList == null || CarouselleList.Count < 3)
            Debug.LogError("Il faut 3 Carouselle dans CarouselleList !");
    }

    private void Start()
    {
        Draw();
    }

    public void ValidateTeam()
    {
        teamData.i_name = inputFieldGrabberList[0].getInputText();
        teamData.i_nickName = inputFieldGrabberList[1].getInputText();

        teamData.i_LogoBack = CarouselleList[0].GetSprite();
        teamData.i_LogoCrown = CarouselleList[1].GetSprite();
        teamData.i_Logo = CarouselleList[2].GetSprite();

#if UNITY_EDITOR

        EditorUtility.SetDirty(teamData);
        AssetDatabase.SaveAssets();
#endif

        Debug.Log("[ValidateTeam] TeamData mise à jour avec les 3 sprites colorés.");
    }

    public void Submit()
    {
        Skin skin = new()
        {
            i_hairSitting = hair.GetSprite(true),
            i_faceSitting = face.GetSprite(true),
            i_shirtSitting = torso.GetSprite(true),
            i_legsSitting = legs.GetSprite(true),

            i_hairStanding = hair.GetSprite(),
            i_faceStanding = face.GetSprite(),
            i_shirtStanding = torso.GetSprite(),
            i_legsStanding = legs.GetSprite()
        };


        GameManager.Instance.i_manager.i_skin = skin;

        GameManager.Instance.i_manager.i_isGenderMale = isGenderMale;

        GameManager.Instance.i_manager.i_name = nameField.text;
        GameManager.Instance.i_manager.i_lastName = lastNameField.text;
    }

    public void ToggleGender()
    {
        isGenderMale = !isGenderMale;

        Draw();
    }

    void Draw()
    {
        male.sprite = isGenderMale ? maleSelect : maleUnselect;
        female.sprite = !isGenderMale ? femaleSelect : femaleUnselect;
    }
}
