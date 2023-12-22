using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.MenuUis
{
    public class MenuGoldInformationText : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _goldInformationText;
        private void Start()
        {
            _goldInformationText.text = GoldManager.Instance.GoldDataSO.GoldAmount.ToString();
        }
    }

}