using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingUI : MonoBehaviour
{
    public Sprite[] sprites;
    public GameObject[] pieces;
    public GameObject Option1;
    public GameObject Option2;
    public GameObject Option3;
    public PlayerControl playerScript;

    private bool showing = true;

    public void ClickUp()
    {
        Option1.GetComponent<UIImage>().imageNum += 1;
        Option1.GetComponent<UIImage>().updateImage();

        Option2.GetComponent<UIImage>().imageNum += 1;
        Option2.GetComponent<UIImage>().updateImage();

        Option3.GetComponent<UIImage>().imageNum += 1;
        Option3.GetComponent<UIImage>().updateImage();
    }

    public void ClickDown()
    {
        Option1.GetComponent<UIImage>().imageNum -= 1;
        Option1.GetComponent<UIImage>().updateImage();

        Option2.GetComponent<UIImage>().imageNum -= 1;
        Option2.GetComponent<UIImage>().updateImage();
        
        Option3.GetComponent<UIImage>().imageNum -= 1;
        Option3.GetComponent<UIImage>().updateImage();
    }

    public void ShowUI()
    {
        gameObject.SetActive(false);
    }

    public void HideUI()
    {
        gameObject.SetActive(true);
    }

    public void Clicked()
    {
        Debug.Log("Clicked");
        if(showing)
        {
            Debug.Log("Showing");
            playerScript.MenuIsOpen = true;
            HideUI();
        }
        else 
        {
            Debug.Log("Not Showing");
            playerScript.MenuIsOpen = false;
            ShowUI();
        }

        showing = !showing;
    }
}
