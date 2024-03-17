using Sirenix.OdinInspector;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    /* public void SendPlayerInteraction()
     {
         string[] args = new string[] { "test string" }; 
         PlayerActionDetails details = new PlayerActionDetails
         {
             PlayerName = "PlayerName",
             ActionType = ActionType.Interacted,
             SceneName = SceneManager.GetActiveScene().name,
             Parameters = args 
         };

         ActionDispatcher.SendPlayerActionDetails(details);
     }*/
    [Button(ButtonSizes.Large)]
    [LabelText("Send Interaction test")]
    public void SendPlayerTaskDetails()
    {
        string[] args = new string[] { "test string" };
        PlayerActionDetails details = new PlayerActionDetails
        {
            PlayerName = "PlayerName",
            //TaskType = TaskType.Interaction,
            SceneName = SceneManager.GetActiveScene().name,
            Parameters = args
        };
        string serializedDetails = JsonUtility.ToJson(details);
        byte code = 102;
       // ActionDispatcher.SendPlayerJsonDetails(serializedDetails,code);
    }
}
