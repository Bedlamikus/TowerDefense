using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconFace : MonoBehaviour
{
    private Image icon;
    private Icons icons;

    private void Start()
    {
        icon = GetComponentInChildren<Image>();
        icons = FindObjectOfType<Icons>();
        PlayerEvents.clickEnemy.AddListener(ShowFace);
        PlayerEvents.clickPlayer.AddListener(ShowFace);
    }

    private void ShowFace(GameObject GO)
    {
        HideFace();
        var race = GO.GetComponent<Unit>().unitRace;
        icon.sprite = icons.GetIcon(race).image;
        icon.gameObject.SetActive(true);
    }

    private void HideFace()
    {
        icon.gameObject.SetActive(false);
    }
}
