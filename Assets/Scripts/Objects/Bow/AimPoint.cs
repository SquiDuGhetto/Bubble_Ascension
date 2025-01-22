using UnityEngine;

public class AimPoint : MonoBehaviour
{
    [SerializeField] private PlayerBow _bow;

    private void Update()
    {
        Vector3 moveVector = (Vector3.up * _bow.GetAimDirection().x + Vector3.left * _bow.GetAimDirection().y);
        if (_bow.GetAimDirection().x != 0 && _bow.GetAimDirection().y != 0)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
        }
    }
}
