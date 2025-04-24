using UnityEngine;

[CreateAssetMenu(fileName = "TeamData", menuName = "TeamData")]
public class TeamData : ScriptableObject
{
    [Header("Infos générales")]
    public string i_name;
    public string i_nickName;

    [Header("Logos (Sprites)")]
    public Sprite i_LogoBack;
    public Sprite i_LogoCrown;
    public Sprite i_Logo;

    [Header("Couleurs des logos")]
    public Color i_LogoBackColor = Color.white;
    public Color i_LogoCrownColor = Color.white;
    public Color i_LogoMainColor = Color.white;
}
