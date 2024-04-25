using UnityEngine;
using System.Collections;

public class LavaManager : MonoBehaviour
{
    public float speed = 0.4f; // Speed for moving the plane vertically
    public float scrollSpeed = 0.1f; // Scroll speed for the lava texture
    public string textureName = "_MainTex"; // Name of the texture property in the shader
    private Renderer rend; // Reference to the Renderer component

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void LateUpdate()
    {
        float offsetX = Time.time * scrollSpeed;
        Vector2 uvOffset = new Vector2(offsetX, 0);

        rend.material.SetTextureOffset(textureName, uvOffset);
    }
}
