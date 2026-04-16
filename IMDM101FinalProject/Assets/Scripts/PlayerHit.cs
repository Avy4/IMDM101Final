using UnityEngine;

public class PlayerHit : MonoBehaviour
{

    private CapsuleCollider2D beatDetectionCollider;
    void Start()
    {
        beatDetectionCollider = GetComponent<CapsuleCollider2D>();
        //beatDetectionCollider.enabled = false;
    }

    void OnAttack()
    {   
        Debug.Log("attack");
        //beatDetectionCollider.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {   
        print("trigger entered");
        GameObject hitObject = collision.gameObject;
        print(hitObject);
        if (hitObject.CompareTag("Beat"))
        {
            Debug.Log("Beat has been hit");
            hitObject.GetComponent<Beat>().GetScore();
        }
    }
}
