using UnityEngine;
public interface IPickable
{
    void OnTouch(GameObject target);
    void OnLeft(GameObject target);
}