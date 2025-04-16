using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class Inject : MonoBehaviour
{
    private string playfabPlayerID = "examplePlayerID"; // Example Player ID
    private int banDurationInHours = 0; // Default to permanent ban (0 hours)

    void Start()
    {
        // Example: Set the ban duration dynamically (in hours) from some UI or configuration
        // This value would ideally be passed in from the HTML/JS side when installing the anti-cheat
        banDurationInHours = 24; // Let's say we set this to 24 hours for now

        // Call function to apply the ban with the given duration
        TryBanPlayer(playfabPlayerID, banDurationInHours);
    }

    void TryBanPlayer(string playerId, int banDuration)
    {
        // Convert the ban duration from hours to seconds (as PlayFab API requires time in seconds)
        int banDurationInSeconds = banDuration * 3600;

        // Create a request to apply a ban on PlayFab
        var request = new ExecuteCloudScriptRequest()
        {
            FunctionName = "BanPlayerByID",
            FunctionParameter = new
            {
                playerId = playerId,
                banDurationInSeconds = banDurationInSeconds // Pass the duration to the cloud script
            },
            GeneratePlayStreamEvent = true
        };

        PlayFabClientAPI.ExecuteCloudScript(request, OnBanSuccess, OnError);
    }

    private void OnBanSuccess(ExecuteCloudScriptResult result)
    {
        Debug.Log("Player banned successfully.");
    }

    private void OnError(PlayFabError error)
    {
        Debug.LogError("Error banning player: " + error.GenerateErrorReport());
    }
}
