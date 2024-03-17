using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerEvents  
{

    public event Action<string> OnMultiplayerFinishedTask;
    public void  MultiplayerFinishedTask(string missionID)
    {
        OnMultiplayerFinishedTask?.Invoke(missionID);
    }

    public event Action<string, string> OnMultiplayerFailed;
    public void MultiplayerFailed(string missionID,string scene)
    {
        OnMultiplayerFailed?.Invoke(missionID,scene);
    }

}
