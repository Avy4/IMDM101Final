using System.Threading.Tasks;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{

    private CapsuleCollider2D beatDetectionCollider;
    void Start()
    {
        beatDetectionCollider = GetComponent<CapsuleCollider2D>();
        beatDetectionCollider.enabled = false;
    }

    async Task OnAttack()
    {   
        beatDetectionCollider.enabled = true;
        // 10 Miliseconds, There must be a better way to implement this
        await Task.Delay(10);
        beatDetectionCollider.enabled = false;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {   
        GameObject hitObject = collision.gameObject;
        if (hitObject.CompareTag("Beat"))
        {
            Debug.Log("Beat has been hit");
            hitObject.GetComponent<Beat>().HitObject();
        }
    }
}
