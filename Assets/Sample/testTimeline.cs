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
        // CinemachineTrack�̏�Ԃ�Reset����
        director.Stop();
        director.Play();
    }

    public void SetCameraBinding()
    {
        int index = 0;

        // 1 �` (List�̐� - 1)�͈̔�
        int i = Random.Range(1, cameraTrackList.Count);
        // ���݂�index + i �����X�g�̐��ȏ�̏ꍇ�A0�ɖ߂��ė]�蕪�𑫂�
        if (cameraTrackList.Count <= currentTrackIndex + i)
        {
            index = (currentTrackIndex + i) - cameraTrackList.Count;
        }
        else index = currentTrackIndex + i;

        TimelineAsset timelineAsset = director.playableAsset as TimelineAsset;

        // ���݃J�������ݒ肳��Ă���Track��Binding�����Z�b�g
        director.ClearGenericBinding(timelineAsset.GetOutputTrack(cameraTrackList[currentTrackIndex]));

        // ����Index�ݒ�
        currentTrackIndex = index;
        // �V����Track��Binding�ɃJ������ݒ�  
        director.SetGenericBinding(timelineAsset.GetOutputTrack(cameraTrackList[index]), mainCamera);
        // CinemachineTrack�̏�Ԃ����Z�b�g
        director.Stop();
        director.Play();
    }
}
