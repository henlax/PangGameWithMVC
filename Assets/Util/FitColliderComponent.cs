using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class FitColliderComponent: MonoBehaviour
{
    void Start() {
        var collider = GetComponent<BoxCollider2D>();
        FitBoxColliderToView(collider);
    }

    public void FitBoxColliderToView(BoxCollider2D Collider)
    {
        var rectTransform = transform as RectTransform;
        Collider.offset = rectTransform.rect.position + rectTransform.rect.size / 2;
        Collider.size = rectTransform.rect.size;
    }
}
