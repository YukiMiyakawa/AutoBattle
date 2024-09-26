using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Triggers;
using UniRx;

namespace Common
{
    public sealed class InputManager : MonoBehaviour
    {
        // 各ゲームパッドからの入力をまとめ、出力する際のレイヤー分けを行うクラス
        // UIを開いている時、バトル画面の時など
        // ゲームパッド毎にボタン名が違っていてめんどくさそう、まとめる方法を勉強しながらとりあえずキーボード入力で実装
        // https://nekojara.city/unity-input-system-intro


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
        public void SetInputLayer(InputLayer layer)
        {
            _layer = layer;
        }


        /// <summary>
        /// 入力定義　※仮
        /// </summary>
        public IObservable<Unit> OnUpKeyAsObservable()
        {
            return this.UpdateAsObservable().Where(_ => Input.GetKey(KeyCode.UpArrow));
        }

        public IObservable<Unit> OnDownKeyAsObservable()
        {
            return this.UpdateAsObservable().Where(_ => Input.GetKey(KeyCode.DownArrow));
        }
        public IObservable<Unit> OnLeftKeyAsObservable()
        {
            return this.UpdateAsObservable().Where(_ => Input.GetKey(KeyCode.LeftArrow));
        }
        public IObservable<Unit> OnRightKeyAsObservable()
        {
            return this.UpdateAsObservable().Where(_ => Input.GetKey(KeyCode.RightArrow));
        }

        public IObservable<Vector3> OnDirectionKeyAsObserble()
        {
            return this.UpdateAsObservable()
                .Select(_ => new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
        }

        public IObservable<Unit> OnJumpAsObserble()
        {
            return this.UpdateAsObservable().Where(_ => Input.GetKey(KeyCode.Space));
        }
    }
}
