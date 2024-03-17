public struct PlayerTaskDetails
{
    public string PlayerName;
    public int PlayerID;
    public string SceneName;
    public System.DateTime Timestamp;

    public TaskType TaskType; 
    public string misionID;
    public string taskID;
    public string HudString;
    public string[] Parameters;
}
public struct GeneralEvent
{
    public string jsonSerialized;
    public string playerID;
    public string playerName;
    public string scenewName;
}