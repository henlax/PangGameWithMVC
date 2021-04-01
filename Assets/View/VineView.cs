using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class VineView : PangElement
{
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = (transform as RectTransform);
        rectTransform.sizeDelta = new Vector2(10,(App.View.VineContainer as RectTransform).rect.height);
    }

    private void Update()
    {
        rectTransform.localPosition += new Vector3(0, 1,0) * App.Model.VineSpeed * App.Model.CanvasScale * Time.deltaTime *50;

        if (rectTransform.anchoredPosition.y >= rectTransform.rect.height)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //It can only be a ball because of the Collision Matrix, all other layers are ignored

        var ball = collider.gameObject.GetComponent<BallView>();

        //Checks anyway, maybe someone messed it up
        if (ball == null) return;

        App.Controller.Vines.HitBall(ball);

        Destroy(gameObject);
    }
}
