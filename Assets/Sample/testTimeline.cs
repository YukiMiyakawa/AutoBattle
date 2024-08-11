using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class testTimeline : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private PlayableDirector director;
    [SerializeField] private List<int> cameraTrackList;
    private int currentTrackIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        TimelineAsset timelineAsset = director.playableAsset as TimelineAsset;
        director.SetGenericBinding(timelineAsset.GetOutputTrack(cameraTrackList[currentTrackIndex]), mainCamera);
        // CinemachineTrackの状態をResetする
        director.Stop();
        director.Play();
    }

    public void SetCameraBinding()
    {
        int index = 0;

        // 1 ～ (Listの数 - 1)の範囲
        int i = Random.Range(1, cameraTrackList.Count);
        // 現在のindex + i がリストの数以上の場合、0に戻って余剰分を足す
        if (cameraTrackList.Count <= currentTrackIndex + i)
        {
            index = (currentTrackIndex + i) - cameraTrackList.Count;
        }
        else index = currentTrackIndex + i;

        TimelineAsset timelineAsset = director.playableAsset as TimelineAsset;

        // 現在カメラが設定されているTrackのBindingをリセット
        director.ClearGenericBinding(timelineAsset.GetOutputTrack(cameraTrackList[currentTrackIndex]));

        // 次のIndex設定
        currentTrackIndex = index;
        // 新しいTrackのBindingにカメラを設定  
        director.SetGenericBinding(timelineAsset.GetOutputTrack(cameraTrackList[index]), mainCamera);
        // CinemachineTrackの状態をリセット
        director.Stop();
        director.Play();
    }
}
