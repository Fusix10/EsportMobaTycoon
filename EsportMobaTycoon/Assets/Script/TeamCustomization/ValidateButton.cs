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
    [SerializeField] private List<TeamCustom> teamCustomList;


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
        /*if (CarouselleList == null || CarouselleList.Count < 3)
            Debug.LogError("Il faut 3 Carouselle dans CarouselleList !");*/
    }

    private void Start()
    {
        Draw();
    }
    [ContextMenu("▶ Validate Team (Editor)")]
    public void ValidateTeam()
    {
        if (nameField != null && lastNameField != null)
        {
            teamData.i_name = nameField.text;
            teamData.i_nickName = lastNameField.text;
        }

        // 3 sprites
        if (teamCustomList != null)
        {
            if (teamCustomList.Count > 0 && teamCustomList[0] != null)
                teamData.i_LogoBack = teamCustomList[0].GetShapeSprite();

            if (teamCustomList.Count > 1 && teamCustomList[1] != null)
            {
                teamData.i_LogoCrown = teamCustomList[1].GetLogoSprite();
            }

            if (teamCustomList.Count > 2 && teamCustomList[2] != null)
                teamData.i_Logo = teamCustomList[2].GetBorderSprite();
        }

#if UNITY_EDITOR
        EditorUtility.SetDirty(teamData);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
#endif

        Debug.Log("[ValidateTeam] opérations terminées, sprites manquants ignorés.");
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
        if (male != null)
            male.sprite = isGenderMale ? maleSelect : maleUnselect;

        if (female != null)
            female.sprite = !isGenderMale ? femaleSelect : femaleUnselect;
    }
}
