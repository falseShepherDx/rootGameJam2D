using UnityEngine;

public class BackgroundLimiter : MonoBehaviour
{
    public Transform background;

    private void LateUpdate()
    {
        float backgroundHeight = background.GetComponent<SpriteRenderer>().bounds.size.y;
        float backgroundTop = background.position.y + backgroundHeight / 2;
        float backgroundBottom = background.position.y - backgroundHeight / 2;

        Vector3 position = transform.position;
        position.y = Mathf.Clamp(position.y, backgroundBottom, backgroundTop);
        transform.position = position;
    }
}

