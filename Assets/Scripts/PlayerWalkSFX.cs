using UnityEngine;

public class PlayerWalkSFX : MonoBehaviour
{
    [SerializeField] GameObject FootstepSFX;

    GameObject footstepInstantiated;
    Vector3 oldPosition;

    void Start()
    {
        oldPosition = transform.position;
    }

    void Update()
    {
        var currentPosition = transform.position;

        if ((Input.GetButton("Horizontal") || Input.GetButton("Vertical")) && footstepInstantiated == null)
        {
            footstepInstantiated = Instantiate(FootstepSFX, transform.position, Quaternion.identity);
            footstepInstantiated.transform.parent = gameObject.transform;
        }
        
        if (currentPosition == oldPosition && footstepInstantiated != null)
            Destroy(footstepInstantiated);

        oldPosition = currentPosition;
    }
}
