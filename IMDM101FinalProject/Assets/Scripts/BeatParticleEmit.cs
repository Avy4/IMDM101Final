using UnityEngine;

public class BeatParticleEmit : MonoBehaviour
{
    [SerializeField] Sprite[] textures;
    private ParticleSystem particleSystem;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    void ChangeAndEmitParticle(int idx)
    {
        particleSystem.textureSheetAnimation.SetSprite(0, textures[idx]);
        particleSystem.Emit(1);
    }
}
