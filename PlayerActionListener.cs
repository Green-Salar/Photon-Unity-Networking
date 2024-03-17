using Sirenix.OdinInspector;
using UnityEngine;
public class PlayerActionListener : SerializedMonoBehaviour
{
    private void OnEnable()
    {
        Debug.Log("@mp_new on enabled");
        PhotonEventManager.OnPlayerActionReceived += HandlePlayerAction;
    }

    private void OnDisable()
    {
        Debug.Log("@mp_new on disabled");
        PhotonEventManager.OnPlayerActionReceived -= HandlePlayerAction;
    }

    private void HandlePlayerAction(PlayerActionDetails actionDetails)
    {  
        object[] parameters = actionDetails.Parameters;
        if (parameters != null) Debug.Log(parameters);
        if (parameters != null && (parameters[0] is string)) {
            string str = (string)parameters[0];
            Debug.Log(" @mp_new event recived:" + actionDetails.PlayerName + " scene : " + actionDetails.SceneName + " obj:string " + str);
        }
        else
        {
            Debug.Log("@mp_new obj params not an string" + parameters);
        }


    }
}