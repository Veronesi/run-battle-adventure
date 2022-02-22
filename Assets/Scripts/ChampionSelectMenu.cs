using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ChampionSelectMenu : MonoBehaviour
{
    // Referencia a imagenes del tablero
    public Image ChampionSelected0;
    public Image ChampionSelected1;
    public Image ChampionSelected2;
    public Image ChampionSelected3;

    public GameObject CardOgreBlue;
    public GameObject CardWizardGreen;
    public GameObject CardOldTree;

    private IChampion[] ListChampions = new IChampion[4];
    private Image[] ChampionSelectedList = new Image[4];
    void Start()
    {
        ChampionSelectedList[0] = ChampionSelected0;
        ChampionSelectedList[1] = ChampionSelected1;
        ChampionSelectedList[2] = ChampionSelected2;
        ChampionSelectedList[3] = ChampionSelected3;

        CardOgreBlue.SetActive(GameManager.instance.playerData.ChampionsUnlock[1] == 1);
        CardOgreBlue.SetActive(GameManager.instance.playerData.ChampionsUnlock[2] == 1);
        CardOgreBlue.SetActive(GameManager.instance.playerData.ChampionsUnlock[3] == 1);
    }

    public void removeChampion(int position)
    {
        ChampionSelectedList[position].enabled = false;
        ChampionSelectedList[position].sprite = null;
        ListChampions[position] = null;
    }

    public void clickChampion(int id)
    {
        IChampion champion = ChampionManager.getChampionById(id);

        int i = 0;
        while(i < ChampionSelectedList.Length)
        {
            // verificamos cual es el proximo slot vacio
            if(ChampionSelectedList[i].sprite == null)
            {
                ListChampions[i] = champion;
                ChampionSelectedList[i].sprite = champion.spriteIamge;
                ChampionSelectedList[i].enabled = true;
                return;
            }
            i++;
        }
    }

    public void HidePanel()
    {
        for (int i = 0; i < ListChampions.Length; i++)
        {
            if (ListChampions[i] != null)
            {
                GameManager.instance.playerData.SetChampionSelected(i, ListChampions[i].id);
            }
            else
            {
                GameManager.instance.playerData.SetChampionSelected(i, 0);
            }
            
        }
        
        Destroy(gameObject);
        GameManager.instance.StartGame();
    }
}
