using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Triggers;
using UniRx;

public class InputManager : MonoBehaviour
{
    // �e�Q�[���p�b�h����̓��͂��܂Ƃ߁A�o�͂���ۂ̃��C���[�������s���N���X
    // UI���J���Ă��鎞�A�o�g����ʂ̎��Ȃ�
    // �Q�[���p�b�h���Ƀ{�^����������Ă��Ă߂�ǂ��������A�܂Ƃ߂���@��׋����Ȃ���Ƃ肠�����L�[�{�[�h���͂Ŏ���


    public static InputManager Instance;
    private void Awake()
    {
        Instance = this;
    }


    /// <summary>
    /// ���ݓ��͂��󂯕t���Ă����ʂ̃��C���[
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
    /// ���͒�`
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
