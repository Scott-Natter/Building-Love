using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIImage : MonoBehaviour
{
    public int imageNum;
    public Sprite image;
    public BuildingUI buildingUI;
    private SpriteRenderer spriteRenderer;
    public GameObject currentObj;
    public PlayerControl player;
    public int nub_wood;
    public GameObject bridge;

    void Start()
    {
        buildingUI = transform.parent.GetComponent<BuildingUI>();
        image = GetComponent<Sprite>();
        image = buildingUI.sprites[imageNum];
        gameObject.GetComponent<Image>().sprite = image;
        currentObj = buildingUI.pieces[imageNum];
    }

    void Update()
    {
        bridge = currentObj;
        nub_wood = player.nub_wood;
    }

    public void updateImage()
    {
        if(imageNum == 6)
            imageNum = 0;
        if(imageNum == -1)
            imageNum = 5;
        image = buildingUI.sprites[imageNum];
        currentObj = buildingUI.pieces[imageNum];
        gameObject.GetComponent<Image>().sprite = image;
    }

    public void CreateBridge()
    {
        if (nub_wood > 0)
        {
            nub_wood--;
            player.MakeBridge(bridge);      
        }
    }
}
