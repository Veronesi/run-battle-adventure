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

    }

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        ChargeEnergy();
    }

    public void StartGame()
    {
        StartSpawnEnemies();
        int[] championsSelected = playerData.ChampionsSelected;
        for(int i = 0; i < championsSelected.Length; i++)
        {
            cards[i] = Instantiate(dictionaryCard[championsSelected[i]], table.transform.GetChild(i).transform);
        }
    }

    public void StartSpawnEnemies()
    {
        GameObject enemy1 = Instantiate(dictionaryCard[0].transform.GetComponentInChildren<DragableCard>().champion, new Vector3(6f, 0f, 10f), Quaternion.identity);
        GameObject enemy2 = Instantiate(dictionaryCard[2].transform.GetComponentInChildren<DragableCard>().champion, new Vector3(8f, 0f, 10f), Quaternion.identity);
        enemy1.tag = "Enemy";
        enemy2.tag = "Enemy";
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

    public PlayerData playerData
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
    private PlayerData _playerData;
}
