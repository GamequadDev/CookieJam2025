using UnityEngine;

[CreateAssetMenu(fileName = "DamageEffect", menuName = "Cards/Effect/Damage")]
public class DamageEffect : CardEffect
{
    public float damage;
   
    public override void ApplyEffect()
    {
        Debug.Log("Apply Damage");
    }
}
