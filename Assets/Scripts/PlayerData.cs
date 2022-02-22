using UnityEngine;

public class PlayerData
{
    private const string name = "Name";
    public string Name
    {
        get { return PlayerPrefs.GetString(name); }
        set { PlayerPrefs.SetString(name, value); }
    }
    private const string level = "Level";
    public int Level
    {
        get { return PlayerPrefs.GetInt(level, 1); }
        set { PlayerPrefs.SetInt(level, value); }
    }
    private const string exp = "Experience";
    public int Experience
    {
        get { return PlayerPrefs.GetInt(exp); }
        set { PlayerPrefs.SetInt(exp, value); }
    }
    private const string money = "Money";
    public float Money
    {
        get { return PlayerPrefs.GetFloat(money); }
        set { PlayerPrefs.SetFloat(money, value); }
    }
    /*
    public int[] ChampionsSelected2()
    {
        int[] req = new int[4];
        req[0] = PlayerPrefs.GetInt("championSelected0");
        req[1] = PlayerPrefs.GetInt("championSelected1");
        req[2] = PlayerPrefs.GetInt("championSelected2");
        req[3] = PlayerPrefs.GetInt("championSelected3");
        return req;
    }
    */

    public const string championsSelected = "ChampionsSelected";
    public IChampion[] ChampionsSelected
    {
        get
        {
            IChampion[] req = new IChampion[4];
            req[0] = ChampionManager.getChampionById(PlayerPrefs.GetInt($"{championsSelected}0"));
            req[1] = ChampionManager.getChampionById(PlayerPrefs.GetInt($"{championsSelected}1"));
            req[2] = ChampionManager.getChampionById(PlayerPrefs.GetInt($"{championsSelected}2"));
            req[3] = ChampionManager.getChampionById(PlayerPrefs.GetInt($"{championsSelected}3"));
            return req;
        }
    }
    public void SetChampionSelected(int position, int champion)
    {
        PlayerPrefs.SetInt(championsSelected + position, champion);
    }

    public const string championsUnlock = "ChampionsUnlock";
    public int[] ChampionsUnlock
    {
        get
        {
            int[] req = new int[4];
            req[0] = 0;
            req[1] = PlayerPrefs.GetInt($"{championsUnlock}1");
            req[2] = PlayerPrefs.GetInt($"{championsUnlock}2");
            req[3] = PlayerPrefs.GetInt($"{championsUnlock}3");
            return req;
        }
    }
}