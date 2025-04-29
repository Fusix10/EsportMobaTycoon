using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] Player i_player;
    [SerializeField] CharacterSkin i_skin;

    [SerializeField] SimplePressPanel i_smallMenu;
    [SerializeField] GameObject i_longMenu;

    [SerializeField] PlayerPanelUI panel;

    private void Start()
    {
    #if DEBUG
            i_player = GameManager.Instance.i_playerFactory.CreateRandomPlayer();
    #endif

        ResetUI();
    }

    public void SetSkin(Skin skin) => i_skin.SetSkin(skin);

    public void Sitting(bool sitting) => i_skin.SetStanding(sitting);

    public void PressGameObject()
    {
        ResetUI();
        i_smallMenu.gameObject.SetActive(true);
        i_smallMenu.InitStat(i_player.i_name, i_player.i_morale, i_player.i_lvl, i_player.i_potentiel);
    }

    public void PressLongGameObject()
    {
        ResetUI();
        panel.SetPlayer(i_player);
        i_longMenu.SetActive(true);
    }

    private void ResetUI()
    {
        i_smallMenu.gameObject.SetActive(false);
        i_longMenu.SetActive(false);
    }
}
