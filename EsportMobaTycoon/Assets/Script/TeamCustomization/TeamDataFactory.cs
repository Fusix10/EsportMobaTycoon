using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class TeamDataFactory : MonoBehaviour
{
    [Header("Logos (Sprites)")]
    public List<Sprite> i_LogoCrowns;
    public List<Sprite> i_Logos;

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


    public void CreateTeamDataFromScratch(int potentiel = 0)
    {

        TeamData teamData = new TeamData();
        int id = UnityEngine.Random.Range(0, 20);

        teamData.i_name = i_allName[id];
        teamData.i_nickName = i_allNickName[id];

        teamData.i_Logo = i_Logos[UnityEngine.Random.Range(0, i_Logos.Count)];
        teamData.i_LogoCrown = i_LogoCrowns[UnityEngine.Random.Range(0, i_LogoCrowns.Count)];

        teamData.i_players.Add(GameManager.Instance.GetComponent<PlayerFactory>().CreateRandomPlayerDataWithRole(GameManager.Role.ADC, potentiel));

        teamData.i_players.Add(GameManager.Instance.GetComponent<PlayerFactory>().CreateRandomPlayerDataWithRole(GameManager.Role.SUPPORT, potentiel));

        teamData.i_players.Add(GameManager.Instance.GetComponent<PlayerFactory>().CreateRandomPlayerDataWithRole(GameManager.Role.MIDLANER, potentiel));

        teamData.i_players.Add(GameManager.Instance.GetComponent<PlayerFactory>().CreateRandomPlayerDataWithRole(GameManager.Role.JUNGLER, potentiel));

        teamData.i_players.Add(GameManager.Instance.GetComponent<PlayerFactory>().CreateRandomPlayerDataWithRole(GameManager.Role.TOPLANER, potentiel));
   
    }
}
