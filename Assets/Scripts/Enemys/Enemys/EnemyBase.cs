using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class EnemyBase : MonoBehaviour
{
    public Rigidbody _myRb { get; private set; }
    public Transform _playerTr { get; private set; }
    public Transform _enemyTr { get; private set; }

    [field: SerializeField] public float _speedOfRotate { get; private set; } = 1;
    [field: SerializeField] public float _speedOfMove { get; private set; } = 5; 
    [field: Range(10, 50), SerializeField] public float _minDistanceLookTarget { get; private set; } = 25;

    [field: Range(10, 50), SerializeField]  public float _minDistanceFollowTarget { get; private set; } = 25;
    

    
    [field: SerializeField] public bool isIdle { get; private set; } = true;
    [field: SerializeField] public bool isFollowTarget { get; private set; }
    [field: SerializeField] public bool isLookTarget { get; private set; } 
    [field: SerializeField] public bool isRandomMove { get; private set; } 
    [field: SerializeField] public bool isRandomRotate { get; private set; }
     
    [field: Range(1, 15), SerializeField] public float timeAFC { get; private set; } = 5f; 


    void Awake()
    {
        _myRb = GetComponent<Rigidbody>();
        _enemyTr = GetComponent<Transform>();
        _playerTr = FindObjectOfType<Player>().transform;
    }
    private void Update()
    { 
        Threchold(); 
        isRandomMove = !isIdle && !isFollowTarget;
        isRandomRotate = !isLookTarget;
        isLookTarget = IsMinDistance(_minDistanceLookTarget);
        isFollowTarget = IsMinDistance(_minDistanceFollowTarget); 
    }

    public bool IsMinDistance(float minDistance)
    {
        return Vector3.Distance(_enemyTr.position, _playerTr.position) <= minDistance;
    }

    private void Threchold()
    {
        timeAFC -= Time.deltaTime;
        if (timeAFC <= 0)
        {
            timeAFC = Random.Range(3, 10);
            isIdle = !isFollowTarget;
            if (!isFollowTarget) StartCoroutine(IdleWaiteTime());
        }
    }
    private IEnumerator IdleWaiteTime()
    {
        isIdle = true;
        yield return new WaitForSeconds(Random.Range(3, 10));
        isIdle = false;
    } 
}
