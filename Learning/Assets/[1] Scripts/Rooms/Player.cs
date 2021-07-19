using System;
using System.Collections.Generic;
using Extensions;
using UnityEditor;
using UnityEngine;

namespace Rooms
{
    [ExecuteInEditMode]
    public class Player : MonoBehaviour
    {
        [SerializeField] private bool _ready;
        [SerializeField] private Room _roomToJoin;
        [SerializeField] private string _chatMessage = String.Empty;

        [Header("Read only")] [SerializeField] private Room _connectedRoom;
        [SerializeField] private List<string> _log = new List<string>();
        [SerializeField] private PlayerStatus _status;

        private void OnEnable()
        {
            AssemblyReloadEvents.afterAssemblyReload += AssemblyReloadEventsOnafterAssemblyReload;
        }

        private void OnDisable()
        {
            AssemblyReloadEvents.afterAssemblyReload -= AssemblyReloadEventsOnafterAssemblyReload;
        }

        private void AssemblyReloadEventsOnafterAssemblyReload()
        {
            // assembly reload resets event subscriptions
            if (_connectedRoom != null)
            {
                _connectedRoom.ChatMessageReceived += ConnectedRoomOnChatMessageReceived;
                _connectedRoom.StatusUpdated += ConnectedRoomOnStatusUpdated;
            }
        }

        [EditorButton]
        private void ConnectToRoom()
        {
            if (_roomToJoin == null)
            {
                Log("Room to join is not selected!");
                return;
            }
            
            if (_connectedRoom != null)
            {
                LeaveRoom();
            }

            if (_roomToJoin.JoinRoom(this))
            {
                Log("connected to room " + _roomToJoin.name);
                _connectedRoom = _roomToJoin;
                _connectedRoom.ChatMessageReceived += ConnectedRoomOnChatMessageReceived;
                _connectedRoom.StatusUpdated += ConnectedRoomOnStatusUpdated;
                // event is firing before subscription, so
                ConnectedRoomOnStatusUpdated(_connectedRoom.Status);
                _status = PlayerStatus.InRoom;
            }
            else
            {
                Log("couldn't connect to " + _roomToJoin.name);
            }
        }

        [EditorButton]
        private void LeaveRoom()
        {
            if (_connectedRoom == null)
            {
                // leave current room
                Log("not connected to any room so cant leave!");
                return;
            }

            _connectedRoom.LeaveRoom(this);
            Log("left room " + _connectedRoom.name);
            _connectedRoom.ChatMessageReceived -= ConnectedRoomOnChatMessageReceived;
            _connectedRoom.StatusUpdated -= ConnectedRoomOnStatusUpdated;
            _connectedRoom = null;
            _status = PlayerStatus.InLobby;
        }

        [EditorButton]
        private void SendMessage()
        {
            if (_chatMessage.Equals(String.Empty))
            {
                Log("Sending empty message!");
                return;
            }

            if (_connectedRoom == null)
            {
                Log("not connected to any room so can't send the message!");
                return;
            }

            if (_status == PlayerStatus.InRoomGame && !_ready)
            {
                Log("is not ready while in game so can't use chat");
                return;
            }

            _connectedRoom.SendMessageToChat(this, _chatMessage);
        }

        [EditorButton]
        private void OutLog()
        {
            Debug.LogWarning("Player " + name + " log:--------------------------");
            foreach (var message in _log)
            {
                Debug.Log(message);
            }

            Debug.LogWarning("--------------------------");
        }

        [EditorButton]
        private void ResetLog()
        {
            _log.Clear();
        }

        private void ConnectedRoomOnChatMessageReceived(string message)
        {
            if (_status == PlayerStatus.InRoom || (_status == PlayerStatus.InRoomGame && _ready))
                 Log(message);
        }

        private void ConnectedRoomOnStatusUpdated(RoomStatus status)
        {
            _status = status == RoomStatus.Game ? PlayerStatus.InRoomGame : PlayerStatus.InRoom;
        }

        private void Log(string message)
        {
            message = "Player " + name + ": " + message;
            Debug.Log(message);
            _log.Add(message);
        }
    }
}