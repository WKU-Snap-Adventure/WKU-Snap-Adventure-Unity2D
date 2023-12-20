using UnityEngine;

[System.Serializable]
public class PlayerInfo
{
    public int user_id;
    public string item_name;

    // Given JSON input:
    // {"name":"Dr Charles","lives":3,"health":0.8}
    // this example will return a PlayerInfo object with
    // name == "Dr Charles", lives == 3, and health == 0.8f.
}
