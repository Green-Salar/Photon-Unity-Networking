using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

using Sirenix.OdinInspector;
using Photon.Pun.Demo.PunBasics; 

public struct NetworkedPlayerDetails
{
    public string PlayerName;
    public int PlayerAvatarNum;
    public string PlayerID;
    public string CurrentMissionID;
    public string CurrentTaskID;
    public int PlayerComplitedTasks;
    public string PlayerCurrentScene;
}

public struct PlayerNetworkedAction
{
    public TaskType TaskType;
    //public TaskData TaskData;
   // public Mission Mission;
    public string MissionID;
    public string SceneName;
    public System.DateTime Timestamp;
    public string PlayerName;
    public int PlayerID;
    public string HudString;
    public string[] Parameters;
}

public class PlayerNetworkingManager : MonoBehaviourPunCallbacks
{
    public MultiplayerUIElementHandler mpUIElementHandler;
    private int avatarNum;
    private string currentScene;
    public static PlayerNetworkingManager Instance { get; private set; }
    private Dictionary<int, List<PlayerNetworkedAction>> playersActionHistory = new Dictionary<int, List<PlayerNetworkedAction>>();
    private List<NetworkedPlayerDetails> networkedPlayerDetailsList = new List<NetworkedPlayerDetails>();

    public List<NetworkedPlayerDetails> NetworkedPlayerDetailsList 
    { 
        get{return networkedPlayerDetailsList; 
        } 
    }


    public Dictionary<int, List<PlayerNetworkedAction>> PlayersActionHistory
    {
        get { return playersActionHistory; }
    }

    public List<string> otherPlayerItemLooted, otherPlayerSceneVisited;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }



    /*
    private void OnEnable()
    {
        GameEventsManager.Instance.missionEvents.OnTaskStepStateChange += UpdateOrCreateMissionElement;
        GameEventsManager.Instance.missionEvents.OnInitiateMission += CreateMissionUIElementOnStartTask;
        GameEventsManager.Instance.missionEvents.OnAdvanceMission += CreateMissionUIElementOnEndTask;
        GameEventsManager.Instance.miscEvents.OnItemLooted += UpdateOrCreateMissionElement;
        GameEventsManager.Instance.miscEvents.OnSnapshot += UpdateOrCreateMissionElement;

        GameEventsManager.Instance.missionEvents.OnTaskInit += ExecuteFuncQueueStart;
        GameEventsManager.Instance.missionEvents.OnFinishTask += ExecuteFuncQueueEnd;
    }

    private void OnDisable()
    {
        GameEventsManager.Instance.missionEvents.OnTaskStepStateChange -= UpdateOrCreateMissionElement;
        GameEventsManager.Instance.missionEvents.OnInitiateMission -= CreateMissionUIElementOnStartTask;
        GameEventsManager.Instance.missionEvents.OnAdvanceMission -= CreateMissionUIElementOnEndTask;
        GameEventsManager.Instance.miscEvents.OnItemLooted -= UpdateOrCreateMissionElement;
        GameEventsManager.Instance.miscEvents.OnSnapshot -= UpdateOrCreateMissionElement;

        GameEventsManager.Instance.missionEvents.OnTaskInit -= ExecuteFuncQueueStart;
        GameEventsManager.Instance.missionEvents.OnFinishTask -= ExecuteFuncQueueEnd;
    }
    */



}
