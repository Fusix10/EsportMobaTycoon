using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "TeamData", menuName = "TeamData")]
public class TeamData : ScriptableObject
{
    [Header("Infos generales")]
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

   /* [Header("Logos (Sprites)")]
    public List<Sprite> i_LogoBacks;
    public List<Sprite> i_LogoCrowns;
    public List<Sprite> i_Logos;*/

    public List<PlayerData> i_players = new();

    List<string> i_allName = new List<string>
    {
        "ShadowReign",
        "NovaStrike",
        "CrimsonVortex",
        "ObsidianWolves",
        "PhantomCore",
        "IronPulse",
        "SilentHydra",
        "TitanSpectre",
        "VoidRaiders",
        "AetherClash",
        "BlazeUnit",
        "DarkProtocol",
        "QuantumRift",
        "VenomCircuit",
        "PixelReapers",
        "StormBound",
        "EchoElite",
        "FrostVanguard",
        "InfernoHex",
        "CyberDawn"
    };

    List<string> i_allNickName = new List<string>
{
    "Shadow",       // ShadowReign
    "Nova",         // NovaStrike
    "Crimson",      // CrimsonVortex
    "Wolf",         // ObsidianWolves
    "Phantom",      // PhantomCore
    "Pulse",        // IronPulse
    "Hydra",        // SilentHydra
    "Spectre",      // TitanSpectre
    "Raider",       // VoidRaiders
    "Aether",       // AetherClash
    "Blaze",        // BlazeUnit
    "Proto",        // DarkProtocol
    "Rift",         // QuantumRift
    "Venom",        // VenomCircuit
    "Reaper",       // PixelReapers
    "Storm",        // StormBound
    "Echo",         // EchoElite
    "Frost",        // FrostVanguard
    "Hex",          // InfernoHex
    "Cyber"         // CyberDawn
};
    public List<PlayerData> GetTeam()
    {
        return i_players;
    }

    public void AddPlayer(PlayerData player)
    {
        if (i_players.Count < 5)
        {
            i_players.Add(player);
        }
        else
        {
            Debug.LogError("Too Many Player");
        }
    }

    public void AddAllPlayer(List<PlayerData> players)
    {
        if (i_players.Count + players.Count <= 5)
        {
            for (int i = 0; i < players.Count; i++)
            {
                i_players.Add(players[i]);
            }
        }
        else
        {
            Debug.LogError("Too Many Player");
        }
    }

    public void DelPlayer(int id)
    {
        if (i_players.Count > 0 && i_players.Count >= id)
        {
            i_players.RemoveAt(id);
        }
        else
        {
            Debug.LogError("no Player Left or Player Id not found");
        }
    }

    public void DelMulPlayer(List<int> ids)
    {
        for (int i = 0; i < ids.Count; i++)
        {
            if (i_players.Count > 0 && i_players.Count >= ids[i])
            {
                i_players.RemoveAt(ids[i]);
            }
            else
            {
                Debug.LogError("no Player Left or Player Id not found");
            }
        }
    }

    public void CreateAllPlayerFromNothing(int potentiel = 0)
    {
        int id = UnityEngine.Random.Range(0, 20);

        i_name = i_allName[id];
        i_nickName = i_allNickName[id];
/*
        i_Logo = i_Logos[UnityEngine.Random.Range(0, i_Logos.Count)];
        i_LogoCrown = i_LogoCrowns[UnityEngine.Random.Range(0, i_LogoCrowns.Count)];
        i_LogoBack = i_LogoBacks[UnityEngine.Random.Range(0, i_LogoBacks.Count)];*/

        i_players.Add(this.GetComponent<PlayerFactory>().CreateRandomPlayerDataWithRole(GameManager.Role.ADC, potentiel));

        i_players.Add(this.GetComponent<PlayerFactory>().CreateRandomPlayerDataWithRole(GameManager.Role.SUPPORT, potentiel));

        i_players.Add(this.GetComponent<PlayerFactory>().CreateRandomPlayerDataWithRole(GameManager.Role.MIDLANER, potentiel));

        i_players.Add(this.GetComponent<PlayerFactory>().CreateRandomPlayerDataWithRole(GameManager.Role.JUNGLER, potentiel));

        i_players.Add(this.GetComponent<PlayerFactory>().CreateRandomPlayerDataWithRole(GameManager.Role.TOPLANER, potentiel));
    }


}
