using ExitGames.Client.Photon;
using Photon.Pun;
using System;
using UnityEngine;

public class PhotonEventManager : MonoBehaviourPunCallbacks
{
    public static event Action<PlayerActionDetails> OnPlayerActionReceived;
    public static event Action<PlayerTaskDetails> OnPlayerTaskReceived;
    public static event Action<object[]> OnNetworkObjectReceived;
    private void OnEnable()
    {
        PhotonNetwork.NetworkingClient.EventReceived += OnEventReceived;
    }

    private void OnDisable()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= OnEventReceived;
    }

    private void OnEventReceived(EventData photonEvent)
    {
        Debug.Log($"Event received: {photonEvent.Code}");
        // Parse the photon event here and call the appropriate action
        switch (photonEvent.Code)
        {
            //for JSON
            case 102:
                var data = ParseEventGeneral(photonEvent);
                string JSON_Data =(string) data[0]; 
                int _playerID = (int)data[1];
                string playerName = (string)data[1]; 
                string sceneName = (string)data[3];
                object[] objectRecieved = new object[]
                {
                    JSON_Data,
                    _playerID,
                    playerName,
                    sceneName
                };
                OnNetworkObjectReceived?.Invoke(objectRecieved);
                break;
 // Interaction event
            case 105: // Scene change event
            case 106: // Item interaction 
                 
            case 101:
                var actionDetails = ParseEventActionDetails(photonEvent);
                OnPlayerActionReceived?.Invoke(actionDetails); 
                break; 

                 
        }
    }


    private object[] ParseEventGeneral(EventData photonEvent)
    {
        // Event data is expected to be an object array with the first element being the serialized JSON string
        object[] data = photonEvent.CustomData as object[];
        
        return data;
    }
    private PlayerActionDetails ParseEventActionDetails(EventData photonEvent)
    {
        // Event data is expected to be an object array with the first element being the serialized JSON string
        object[] data = photonEvent.CustomData as object[];
        PlayerActionDetails actionDetails = new PlayerActionDetails();
        if (data != null && data.Length > 0 && data[0] is string serializedDetails)
        {
            Debug.Log(serializedDetails);  

             
            actionDetails = JsonUtility.FromJson<PlayerActionDetails>(serializedDetails);

            
            Debug.Log(actionDetails.PlayerID);

        }
        else
        {
            Debug.LogError("Received event data is not in the expected format.");
        }

        return actionDetails;
    }

    private PlayerActionDetails ParseEventOld(EventData photonEvent)
    { 
        object[] data = (object[])photonEvent.CustomData; 
        int _playerId = (int)data[0];
        string playerName = (string)data[1];
        ActionType actionType = (ActionType)data[2];
        string sceneName = (string)data[3];
        string[] Parameters = (string[])data[4];  
        PlayerActionDetails actionDetails = new PlayerActionDetails();
        actionDetails.PlayerName = playerName;
        actionDetails.SceneName = sceneName;
        actionDetails.ActionType = actionType;
        actionDetails.Parameters = Parameters;
        actionDetails.PlayerID = _playerId;
        return new PlayerActionDetails();
    }
}
