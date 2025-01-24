using UnityEngine;

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
    [SerializeField] CardType cardType_;
    [SerializeField] private Material fireMaterial;
    [SerializeField] private Material thunderMaterial;
    [SerializeField] private Material waterMaterial;
    [SerializeField] public float rotationSpeed_ = 0.5f;

    private Camera camera_;
    private Collider collider_;
    private Renderer renderer_;

    private void CheckCardType()
    {
        switch (cardType_)
        {
            case CardType.kFire:
                renderer_.material = fireMaterial;
                break;
                case CardType.kThunder: 
                renderer_.material = thunderMaterial;
                break;
                case CardType.kWater:
                renderer_.material = waterMaterial;
                break;
            default:
                renderer_.material = fireMaterial;
                Debug.Log("material not chosen. def fire.");
                break;
        }
    }

    private void Awake()
    {
        camera_ = Camera.main;
        collider_ = GetComponent<Collider>();
        renderer_ = GetComponent<Renderer>();

        //Component確認
        if (collider_ == null) { Debug.Log("no collider"); }
        if (renderer_ == null) { Debug.Log("Renederer not found on game object"); }

        CheckCardType();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            Debug.Log("colliding....");
            collision.gameObject.SetActive(false);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
