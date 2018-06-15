using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetWork : NetworkBehaviour {
    public enum State
    {
        // Readyになるのを待ってる状態
        WaitReady,
        // Start直前の状態
        Ready,
        // プレイ中の操作可能な状態
        Play,
    }
    // 状態
    [SyncVar]
    public State L_State = State.WaitReady;
    // プレイヤー名
    [SyncVar]
    public string L_PlayerName;

    public bool L_SpawnOnClient;

    // Use this for initialization
    void Start() {
        if (isLocalPlayer)
        {
            CmdInitializeComplete();
        }
    }
    // クライアント上で生成済みであることをサーバーへ通知する
    [Command]
    void CmdInitializeComplete()
    {
        L_SpawnOnClient = true;
    }
    void FixedUpdate()
    {
        if (!isLocalPlayer)
            return;

        if (L_State != State.Play)
            return;
    }
    // Ready状態にする
    public void Ready()
    {
        L_State = State.Ready;
    }
    // Play状態（操作可能）にする
    public void StartPlay()
    {
        L_State = State.Play;
    }

    // Update is called once per frame
    void Update() {
        
    }

}
