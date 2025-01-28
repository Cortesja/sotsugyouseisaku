using UnityEngine;
using static UnityEditor.PlayerSettings;
using UnityEngine.Rendering;

[RequireComponent (typeof(Collider))]

public class SpellCard : MonoBehaviour
{
    enum CardType
    {
        kFire,
        kThunder,
        kWater,
        kTypeCount
    };
    [SerializeField] private Material material_;
    [SerializeField] public float rotationSpeed_ = 0.5f;

    private Camera camera_;
    private Collider collider_;
    private Renderer renderer_;

    private void Awake()
    {
        camera_ = Camera.main;
        collider_ = GetComponent<Collider>();
        renderer_ = GetComponent<Renderer>();

        //Component確認
        if (collider_ == null) { Debug.Log("no collider"); }
        if (renderer_ == null) { Debug.Log("Renederer not found on game object"); }

        renderer_.material = material_;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(transform.position.x, 1.0f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate 180 degrees around the Y-axis
        //ブレンダーのモデルの向きは後ろ向きだったので
        Vector3 testAngle = new Vector3(0f, rotationSpeed_, 0f);
        transform.rotation *= Quaternion.Euler(testAngle);
    }
}
