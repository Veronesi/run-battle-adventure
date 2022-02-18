using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ChampionSelectMenu : MonoBehaviour
{
    public Sprite OGRE_BLUE, OLD_TREE, WIZARD_GREEN;
    public Image ChampionSelected0;
    public Image ChampionSelected1;
    public Image ChampionSelected2;
    public Image ChampionSelected3;
    private int[] ListChampions = new int[4];
    void Start()
    {
        /*
        ChampionSelected0.sprite = null;
        ChampionSelected1.sprite = OGRE_BLUE;
        ChampionSelected2.sprite = WIZARD_GREEN;
        ChampionSelected3.sprite = OLD_TREE;
        */
    }

    public void removeChampion(int position)
    {
        switch (position)
        {
            case 0:
                ChampionSelected0.enabled = false;
                ChampionSelected0.sprite = null;
                ListChampions[0] = 0;
                break;
            case 1:
                ChampionSelected1.enabled = false;
                ChampionSelected1.sprite = null;
                ListChampions[1] = 0;
                break;
            case 2:
                ChampionSelected2.enabled = false;
                ChampionSelected2.sprite = null;
                ListChampions[2] = 0;
                break;
            case 3:
                ChampionSelected3.enabled = false;
                ChampionSelected3.sprite = null;
                ListChampions[3] = 0;
                break;
        }
    }

    public void clickChampion(string name)
    {
        Sprite championSprite = null;
        int championID = 0;
        switch (name)
        {
            case "OGRE_BLUE":
                championSprite = OGRE_BLUE;
                championID = 0;
                break;
            case "OLD_TREE":
                championSprite = OLD_TREE;
                championID = 2;
                break;
            case "WIZARD_GREEN":
                championSprite = WIZARD_GREEN;
                championID = 1;
                break;
        }

        if(ChampionSelected0.sprite == null)
        {
            ChampionSelected0.sprite = championSprite;
            ChampionSelected0.enabled = true;
            ListChampions[0] = championID;
        }
        else if(ChampionSelected1.sprite == null)
        {
            ChampionSelected1.sprite = championSprite;
            ChampionSelected1.enabled = true;
            ListChampions[1] = championID;
        }
        else if (ChampionSelected2.sprite == null)
        {
            ChampionSelected2.sprite = championSprite;
            ChampionSelected2.enabled = true;
            ListChampions[2] = championID;
        }
        else if (ChampionSelected3.sprite == null)
        {
            ChampionSelected3.sprite = championSprite;
            ChampionSelected3.enabled = true;
            ListChampions[3] = championID;
        }
        else
        {
            Debug.Log("equipo completo");
        }
    }

    public void HidePanel()
    {
        for (int i = 0; i < ListChampions.Length; i++)
        {
            GameManager.instance.playerData.SetChampionSelected(i, ListChampions[i]);
        }
        
        Destroy(gameObject);
        GameManager.instance.StartGame();
    }
}
