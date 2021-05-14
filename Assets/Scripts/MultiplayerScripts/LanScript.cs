using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanScript : NetworkManager
{
    
    
    public Transform player1;
    public Transform player2;
    GameObject asteroid;

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        Time.timeScale = 0;
        // add player at correct spawn position
        Transform start = numPlayers == 0 ? player1 : player2;
        GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
        NetworkServer.AddPlayerForConnection(conn, player);

        if (numPlayers == 2)
        {
            Time.timeScale = 1;
        }
    }
}


