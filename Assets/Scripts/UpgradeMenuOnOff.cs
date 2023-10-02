using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenuOnOff : MonoBehaviour
{
    public GameObject upgradeMenu;

    public void TurnOnOffUpgradeMenu(GameObject gObject, int value)
    {
        if (gObject != null)
        {
            if(value == 0)
                upgradeMenu.SetActive(true);
            else
                upgradeMenu.SetActive(false);
        }
        else
        {
            upgradeMenu.SetActive(false);
        }
    }
}
