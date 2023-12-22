using System;
using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.Buttons.MenuButtons.CostumeButtons.CharacterSelection;
using UnityEngine;
using UnityEngine.UI;

public class CostumesPanel : MonoBehaviour
{
    [SerializeField] PlayerSelectButton[] _yellowPlayerSelectButton;
    public List<PlayerSelectButton> yellowPlayerSelectButtons;


    private void OnEnable()
    {
        ListhandleOnSpawn();
    }
    /// <summary>
    /// TODO: OPtimize
    /// </summary>
    List<PlayerDetailSO> playerDetailSOs = new List<PlayerDetailSO>();
    private void ListhandleOnSpawn()
    {
        foreach (PlayerDetailSO item in ShopManager.Instance.PlayerDetailLists)
        {
            playerDetailSOs.Add(item);
            foreach (PlayerSelectButton P in yellowPlayerSelectButtons)
            {
                Debug.Log(item.PlayerTypeEnum + "+" + P._playerDetailSO.PlayerTypeEnum);
                if (item.PlayerTypeEnum == P._playerDetailSO.PlayerTypeEnum)
                {
                    Debug.Log(item + "+" + P);
                    playerDetailSOs.Remove(item);
                    P.transform.gameObject.SetActive(true);
                }
                else
                {
                    Debug.Log(item.PlayerTypeEnum + "+" + P._playerDetailSO.PlayerTypeEnum);
                    Debug.Log("Eşit DEğil");
                }
            }
        }

    }







}
