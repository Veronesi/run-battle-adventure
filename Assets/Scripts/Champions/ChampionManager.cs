using UnityEngine;

public static class ChampionManager
{
    public static IChampion getChampionById(int id)
    {
        switch (id)
        {
            case 1: return new OgreBlue();
            case 2: return new WizardGreen();
            case 3: return new OldTree();
        }

        // Campeon por defecto
        return null;
    }
}
