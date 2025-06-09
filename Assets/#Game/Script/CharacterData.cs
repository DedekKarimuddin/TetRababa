public static class CharacterData
{
    public static void SetCharacter(int player, string characterName)
    {
        SettingsData data = SaveSystem.Load();
        if (player == 1)
            data.selectedCharacterPlayer1 = characterName;
        else
            data.selectedCharacterPlayer2 = characterName;

        SaveSystem.Save(data);
    }
}
