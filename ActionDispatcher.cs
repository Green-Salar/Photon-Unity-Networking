using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class ActionDispatcher
{
    // Method for sending generic actions with additional data
  /*  public static void SendAction(ActionType actionType, string sceneName, string HudString = "undefined action from other player")
    {
        System.DateTime time = System.DateTime.Now;  
        object[] content = new object[] {
            PhotonNetwork.LocalPlayer.ActorNumber,
            PhotonNetwork.LocalPlayer.NickName,
            actionType.ToString(),  
            sceneName,
            HudString,  
            time.ToString()  
        };

        SendEvent(content, GetEventCodeForActionType(actionType));
    }
    */ 
    public static void SendPlayerActionDetails(PlayerActionDetails actionDetails, byte code)
    {
        string serializedDetails = JsonUtility.ToJson(actionDetails);
        object[] content = new object[] { serializedDetails };
         
        SendEvent(content, code);
    }
    public static void SendPlayerJsonDetails(string serializedDetails, string SceneName, byte code)
    { 
        object[] content = new object[]
        {
        serializedDetails,
        PhotonNetwork.LocalPlayer.ActorNumber,
        PhotonNetwork.LocalPlayer.NickName,
        SceneName,
        };
         
        SendEvent(content, code);
    }

    public static void SendTaskFinished(TaskType taskType, string sceneName,string missionID, string taskID=null, string HudString = "undefined action from other player")
    {
        System.DateTime time = System.DateTime.Now;
        object[] content = new object[] {
            PhotonNetwork.LocalPlayer.ActorNumber,
            PhotonNetwork.LocalPlayer.NickName,
            taskType.ToString(),
            sceneName,
            missionID, 
            taskID,
            HudString,
            time.ToString()
        };

        SendEvent(content, 101);//GetEventCodeForTaskType(TaskType));
    }
    private static void SendEvent(object[] content, byte eventCode)
    {
        RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        SendOptions sendOptions = new SendOptions { Reliability = true };

        PhotonNetwork.RaiseEvent(eventCode, content, raiseEventOptions, sendOptions);
        Debug.Log($"Event {eventCode} sent with content: {content[0]}");
    }
     
    private static byte GetEventCodeForTaskType(ActionType taskType)
    {
        return taskType switch
        {
            ActionType.EnteredTheScene => 105,
            ActionType.Interacted => 104,
            ActionType.PickedUp => 106,
            _ => 0,  
        };
    }
}