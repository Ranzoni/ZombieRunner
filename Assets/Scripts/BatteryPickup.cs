using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float angleToRestore = 40f;
    [SerializeField] float lightToRestore = 5f;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
            return;

        var flashLight = FindObjectOfType<FlashLightSystem>();
        flashLight.RestoreLightAngle(angleToRestore);
        flashLight.RestoreLightIntensity(lightToRestore);
        Destroy(gameObject);
    }
}
