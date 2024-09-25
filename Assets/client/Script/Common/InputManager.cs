using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Triggers;
using UniRx;

public class InputManager : MonoBehaviour
{
    // 各ゲームパッドからの入力をまとめ、出力する際のレイヤー分けを行うクラス
    // UIを開いている時、バトル画面の時など
    // ゲームパッド毎にボタン名が違っていてめんどくさそう、まとめる方法を勉強しながらとりあえずキーボード入力で実装


    public static InputManager Instance;
    private void Awake()
    {
        Instance = this;
    }


    /// <summary>
    /// 現在入力を受け付けている画面のレイヤー
    /// </summary>
    public enum InputLayer
    {
        None,
        Battle,
        Town,
        UI
    }

    private InputLayer _layer;
    public InputLayer GetInputLayer => _layer;


    /// <summary>
    /// 入力定義
    /// </summary>
    public IObservable<Unit> OnUpKey()
    {
        return this.UpdateAsObservable().Where(_ => Input.GetKey(KeyCode.UpArrow));
    }

    public IObservable<Unit> OnDownKey()
    {
        return this.UpdateAsObservable().Where(_ => Input.GetKey(KeyCode.DownArrow));
    }
    public IObservable<Unit> OnLeftKey()
    {
        return this.UpdateAsObservable().Where(_ => Input.GetKey(KeyCode.LeftArrow));
    }
    public IObservable<Unit> OnRightKey()
    {
        return this.UpdateAsObservable().Where(_ => Input.GetKey(KeyCode.RightArrow));
    }

}
