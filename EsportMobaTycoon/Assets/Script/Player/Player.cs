using UnityEngine;

public class Player : MonoBehaviour
{
    public string i_name { get; private set; }
    public string i_knickname { get; private set; }
    public GameManager.Role i_role { get; private set; }
    public GameManager.Role i_currentRole { get; set; }
    public Mechanic i_mechanic { get; private set; }
    public Knowledge i_knowledge { get; private set; }
    public Character i_favoriteCharacterId { get; private set; }
    public Character i_characterId { get; private set; }
    public float i_totalLuck { get; private set; }
    public float i_morale { get; private set; }
    public Lvl i_teamSpirit { get; private set; }
    public int i_reputation { get; private set; }
    public int i_lvl { get; private set; }
    public int i_potentiel { get; private set; }
    public Mood i_mood { get; private set; }
    public Skin i_skin { get; protected set; }
    public bool i_isBuddy { get; protected set; }

    public void Init
    (
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
    Skin skin = null,
    bool isBuddy = false
    )
    {
        i_name = name;
        i_knickname = knickname;
        i_role = role;
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

        i_isBuddy = isBuddy;

        if (skin == null) 
        {
            i_skin = CharacterSkinRandom.RandomSkin();
        }
        else
        {
            i_skin = skin;
        }


            i_lvl = i_mechanic.s_lvlCombo[i_favoriteCharacterId.i_Id].s_lvl + i_mechanic.s_stamina.s_lvl + i_mechanic.s_reflexe.s_lvl + i_knowledge.s_placement.s_lvl + i_knowledge.s_teamFight.s_lvl + i_knowledge.s_objective.s_lvl;
        i_lvl = i_lvl / 6;

        UpdateTick();
    }

    public void GainXP(Lvl obj, float Gain)
    {
        if (obj.s_lvl < i_potentiel)
        {
            obj.s_Xp += ((100 - (obj.s_lvl * 5)) * Gain) / 100;
        }

        while (obj.s_Xp > 100)
        {
            obj.s_Xp -= 100;
            obj.s_lvl++;

            if (obj.s_Xp >= 100)
            {
                obj.s_lvl++;
                while (obj.s_Xp > 100)
                {
                    obj.s_Xp -= 100;
                }
            }
        }
    }
    public void Luck()
    {
        float sumLuck = i_mechanic.s_lvlCombo[i_favoriteCharacterId.i_Id].s_lvl + i_mechanic.s_stamina.s_lvl + i_mechanic.s_reflexe.s_lvl + i_knowledge.s_placement.s_lvl + i_knowledge.s_teamFight.s_lvl + i_knowledge.s_objective.s_lvl+i_teamSpirit.s_lvl;
        sumLuck *= (i_morale / 100);
        i_totalLuck = sumLuck;
        i_lvl = (int)Mathf.Round((i_mechanic.s_lvlCombo[i_favoriteCharacterId.i_Id].s_lvl + i_mechanic.s_stamina.s_lvl + i_mechanic.s_reflexe.s_lvl + i_knowledge.s_placement.s_lvl + i_knowledge.s_teamFight.s_lvl + i_knowledge.s_objective.s_lvl) / 6);
    }

    public void UpdateTick()
    {

    }
    private void MoraleEffectOnMorale(bool result, float moraleChange)
    {
        if (result)
        {
            i_morale += moraleChange * i_mood.i_win;
        }
        else
        {
            i_morale += moraleChange * i_mood.i_loose;
        }
    }

    public void ApplyFavoriteCharacterBonus()
    {
        if (i_characterId == i_favoriteCharacterId)
        {
            i_morale *= 1.05f;
        }
    }

    public void ApplyRolePenalty()
    {
        if (i_currentRole != i_role)
        {
            i_totalLuck *= 0.8f;
        }
    }

    public void MatchUpLuck(Player opponent)
    {
        GameManager.MatchUp matchUp = GameManager.Instance.GetMatchUp(i_characterId, opponent.i_characterId);
        if (matchUp.state == GameManager.MatchUp.stateMatchUp.COUNTER)
        {
            i_totalLuck *= 1.3f;
            opponent.i_totalLuck *= 0.7f;
        }
        else if (matchUp.state == GameManager.MatchUp.stateMatchUp.ISCOUNTERED)

        {
            i_totalLuck *= 0.7f;
            opponent.i_totalLuck *= 1.3f;
        }
    }

    public void ChangeLuck(Player opponent)
    {
        i_totalLuck = 0f;
        Luck();
        ApplyFavoriteCharacterBonus();
        ApplyRolePenalty();
        MatchUpLuck(opponent);
    }

    public void SetRole(GameManager.Role newRole)
    {
        i_currentRole = newRole;
    }

}