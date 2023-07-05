using System.Collections;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] float displayDelay = 1f;
    [SerializeField] Canvas displayDamage;

    void OnEnable()
    {
        displayDamage.gameObject.SetActive(false);
    }

    public void Display()
    {
        StartCoroutine(ActiveDisplayForSeconds());
    }

    IEnumerator ActiveDisplayForSeconds()
    {
        displayDamage.gameObject.SetActive(true);

        yield return new WaitForSeconds(displayDelay);

        displayDamage.gameObject.SetActive(false);
    }
}
