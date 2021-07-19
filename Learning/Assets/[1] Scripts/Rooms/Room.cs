using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rooms
{
    public class Room : MonoBehaviour
    {
        public event Action<string> ChatMessageReceived;
        public event Action<RoomStatus> StatusUpdated;
        
        [SerializeField, Range(2, 5)] private int _maxPlayers;

        [Header("Read only")]
        [SerializeField] private List<Player> _players = new List<Player>();
        [SerializeField] private RoomStatus _status;
        [SerializeField] private List<string> _chatLog = new List<string>();

        public RoomStatus Status => _status;

        public bool JoinRoom(Player player)
        {
            if (_players.Contains(player))
            {
                Debug.LogWarning("Player is already in a room!");
                return false;
            }

            if (_players.Count == _maxPlayers)
            {
                Debug.LogWarning("Room is full!");
                return false;
            }
            
            _players.Add(player);
            UpdateRoomStatus();
            return true;
        }

        public bool LeaveRoom(Player player)
        {
            if (!_players.Contains(player))
            {
                Debug.LogWarning("Room does not contains player!");
                return false;
            }

            _players.Remove(player);
            UpdateRoomStatus();
            return true;
        }

        public void SendMessageToChat(Player player, string message)
        {
            ChatMessageReceived?.Invoke("Player " + player.name + "to chat:" + message);
            _chatLog.Add("Player " + player.name + "to chat:" + message);
        }

        private void UpdateRoomStatus()
        {
            _status = _players.Count == _maxPlayers ? RoomStatus.Game : RoomStatus.Waiting;
            StatusUpdated?.Invoke(_status);
        }
    }
}