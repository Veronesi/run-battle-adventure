using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public GameObject table;
    public SpriteRenderer energyBar;
    public GameObject[] cards = new GameObject[4];
    public GameObject[] dictionaryCard;
    public Animator animatorChampionArea;
    public SpriteRenderer championArea;
    public float energy = 0f;
    private float maxEnergy = 10f;
    private void Start()
    {
        int[] championsSelected = playerData.ChampionsSelected;
        for(int i = 0; i < championsSelected.Length; i++)
        {
            cards[i] = Instantiate(dictionaryCard[championsSelected[i]], table.transform.GetChild(i).transform);
        }
    }

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        ChargeEnergy();
    }

    public void AnimationChampionArea(bool active)
    {
        if (active)
        {
            championArea.color = new Color(221f / 255f, 68f / 255f, 44f / 255f, 0.1f);
            return;
        }

        championArea.color = new Color(221f / 255f, 68f / 255f, 44f / 255f, 0f);
    }

    public void ChargeEnergy()
    {
        if(energy < maxEnergy)
        {
            energyBar.size = new Vector2(4.8f * energy / maxEnergy, energyBar.size.y);
            energy += Time.deltaTime / 2;
        }
    }

    public static PlayerData playerData
    {
        get
        {
            if (_playerData == null)
            {
                _playerData = new PlayerData();
            }
            return _playerData;
        }
        set
        {
            _playerData = value;
        }
    }
    private static PlayerData _playerData;
}
