using System.Collections;
using System.Collections.Generic;
using Character.NPC;
using UnityEngine;
using UnityEngine.AI;

public class NpcCommonMoveController : MonoBehaviour
{
    private NpcAnimationController _npcAnimationController;
    private Transform _targetTrn;
    private NavMeshAgent _navMeshAgent;
    private bool _onMpve;

    private bool CanNavMove => _navMeshAgent.pathStatus != NavMeshPathStatus.PathInvalid 
                                && _targetTrn != null
                                && _onMpve;

    public void Initialize(
        Transform targetTrn, 
        NavMeshAgent navMeshAgent, 
        NpcAnimationController npcAnimationController)
    {
        _targetTrn = targetTrn;
        _navMeshAgent = navMeshAgent;
        _npcAnimationController = npcAnimationController;
    }

    private void Update()
    {
        // var speed = _navMeshAgent.velocity.magnitude;
        // _npcAnimationController.SetSpeedTrigger(speed);

        // var isSuccess = _navMeshAgent.SetDestination(_targetTrn.position);
        // Debug.Log("Speed: " + _navMeshAgent.speed);
        // Debug.Log("Acceleration: " + _navMeshAgent.acceleration);
        // Debug.Log("isSuccess " + isSuccess);
        // Debug.Log("PathStatus: " + _navMeshAgent.pathStatus);
        // Debug.Log("Current Target Position: " + _targetTrn.position);
        // Debug.Log("Current Agent Position: " + _navMeshAgent.transform.position);     
        // if (CanNavMove)
        // {
            _navMeshAgent.SetDestination(_targetTrn.position);
        // }
    }

    public void SetOnMove(bool onMove)
    {
        // _onMpve = onMove;
    }
}
