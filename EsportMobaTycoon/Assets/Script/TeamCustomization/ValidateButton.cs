/*using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ValidateButton : MonoBehaviour
{
    [SerializeField] private TeamData teamData;
    [SerializeField] private List<UnputFieldGrabber> inputFieldGrabberList;
    [SerializeField] private List<Carouselle> CarouselleList;
    [SerializeField] private bool isGenderXX;

    void Start()
    {
        if (teamData == null)
            Debug.LogError("TeamData n'est pas assigné !");
        if (CarouselleList == null || CarouselleList.Count < 3)
            Debug.LogError("Il faut 3 Carouselle dans CarouselleList !");
    }

    public void ValidateTeam()
    {
        teamData.i_name = inputFieldGrabberList[0].getInputText();
        teamData.i_nickName = inputFieldGrabberList[1].getInputText();

        teamData.i_LogoBack = CarouselleList[0].getSprite();
        teamData.i_LogoCrown = CarouselleList[1].getSprite();
        teamData.i_Logo = CarouselleList[2].getSprite();

        Color colorBack = CarouselleList[0].getColor();
        Color colorCrown = CarouselleList[1].getColor();
        Color colorMain = CarouselleList[2].getColor();

        Debug.Log($"[ValidateTeam] Back={colorBack}, Crown={colorCrown}, Main={colorMain}");

        teamData.i_LogoBackColor = colorBack;
        teamData.i_LogoCrownColor = colorCrown;
        teamData.i_LogoMainColor = colorMain;

#if UNITY_EDITOR
        EditorUtility.SetDirty(teamData);
        AssetDatabase.SaveAssets();
#endif

        Debug.Log("[ValidateTeam] TeamData mise à jour et sauvegardée.");
    }
}

*/
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ValidateButton : MonoBehaviour
{
    [SerializeField] private TeamData teamData;
    [SerializeField] private List<UnputFieldGrabber> inputFieldGrabberList;
    [SerializeField] private List<TeamCustom> CarouselleList;
    [SerializeField] private bool isGenderXX;

    void Start()
    {
        if (teamData == null)
            Debug.LogError("TeamData n'est pas assigné !");
        if (inputFieldGrabberList == null || inputFieldGrabberList.Count < 2)
            Debug.LogError("Il faut 2 UnputFieldGrabber dans inputFieldGrabberList !");
        if (CarouselleList == null || CarouselleList.Count < 3)
            Debug.LogError("Il faut 3 Carouselle dans CarouselleList !");
    }

    public void ValidateTeam()
    {
        teamData.i_name = inputFieldGrabberList[0].getInputText();
        teamData.i_nickName = inputFieldGrabberList[1].getInputText();

        teamData.i_LogoBack = CarouselleList[0].getSprite();
        teamData.i_LogoCrown = CarouselleList[1].getSprite();
        teamData.i_Logo = CarouselleList[2].getSprite();

#if UNITY_EDITOR

        EditorUtility.SetDirty(teamData);
        AssetDatabase.SaveAssets();
#endif

        Debug.Log("[ValidateTeam] TeamData mise à jour avec les 3 sprites colorés.");
    }

    public void ToggleGender()
    {
        isGenderXX = !isGenderXX;
    }
}
