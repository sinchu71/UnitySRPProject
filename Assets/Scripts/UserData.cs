using UnityEngine;

[CreateAssetMenu(fileName = "UserData", menuName = "ScriptableObjects/UserData", order = 1)]
public class UserData : ScriptableObject
{
    public string userEmail;
    public string userName;
    public string userPassword;
    public int sizePreference;
    public int volumePreference;
    public string locationPreference;
}
