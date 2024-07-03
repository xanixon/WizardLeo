using UnityEngine;

[CreateAssetMenu(fileName = "New Player Static Data", menuName = "Custom/PlayerStaticData")]
public class PlayerStaticData: ScriptableObject
{
    public GameObject PlayerPrefab;
    public float MaxHealth;

    public int MaxMana;
    public GameObject ManaStackItemPrefab;
    public GameObject ManaOnGroundItemPrefab;
    public Vector3 ManaStackSpawnPointOffset;
    public float VerticalStep; //every item on stack spawns a little higher than previous one
    public float HorizontalNoise;
    public float DropSpread;
    public Vector3 DroppedSpawnPoint;
    public float LifeTimeOnDrop;


    public float MovementSpeed;
    public float RotationSpeed;

    public float CameraSmoothness;
    public float CameraFollowDelay;
    public Vector3 CameraOffset;

    public float ProximityListUpdateInterval;
    public int ProximityListMaxSize;

    public float ItemPickupRange;
    public LayerMask ItemLayer;

    


}
