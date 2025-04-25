using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string i_name;
    public string i_knickname;
    public GameManager.Role i_role;
    public GameManager.Role i_currentRole;
    public Sprite i_icon;
    public Mechanic i_mechanic;
    public Knowledge i_knowledge;
    public Character i_favoriteCharacterId;
    public Character i_characterId;
    public float i_totalLuck;
    public float i_morale;
    public Lvl i_teamSpirit;
    public int i_reputation;
    public int i_lvl;
    public int i_potentiel;
    public Mood i_mood;

    public void SetFromPlayer(Player p)
    {
        i_name = p.i_name;
        i_role = p.i_role;
        i_currentRole = p.i_currentRole;
        i_mechanic = p.i_mechanic;
        i_knowledge = p.i_knowledge;
        i_favoriteCharacterId = p.i_favoriteCharacterId;
        i_characterId = p.i_characterId;
        i_totalLuck = p.i_totalLuck;
        i_morale = p.i_morale;
        i_teamSpirit = p.i_teamSpirit;
        i_reputation = p.i_reputation;
        i_lvl = p.i_lvl;
        i_potentiel = p.i_potentiel;
        i_mood = p.i_mood;
    }

    public void SetFromData(
    string name,
    string knickname,
    GameManager.Role role,
    Mechanic mechanic,
    Knowledge knowledge,
    Character favoriteCharacterId,
    Lvl teamSpirit,
    int reputation,
    int potentiel,
    Mood mood,
    GameManager.Role currentRole,
    Character characterId = null,
    Sprite icon = null
    )
    {
        i_name = name;
        i_knickname = knickname;
        i_role = role;
        i_icon = icon;
        i_mechanic = mechanic;
        i_knowledge = knowledge;
        i_favoriteCharacterId = favoriteCharacterId;
        i_teamSpirit = teamSpirit;
        i_reputation = reputation;
        i_potentiel = potentiel;
        i_mood = mood;
        i_characterId = characterId;
        i_currentRole = currentRole;
        i_morale = 100;
    }
}