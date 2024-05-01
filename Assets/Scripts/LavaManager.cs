using UnityEngine;

public class LavaManager : MonoBehaviour
{
    public static LavaManager Instance;

    public float speed = 0.4f; // Speed for moving the plane vertically
    public float scrollSpeed = 0.1f; // Scroll speed for the lava texture
    public string textureName = "_MainTex"; // Name of the texture property in the shader
    private Renderer rend; // Reference to the Renderer component

    private bool isLavaMoving = true;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        rend = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (isLavaMoving)
            transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        float offsetX = Time.time * scrollSpeed;
        Vector2 uvOffset = new Vector2(offsetX, 0);

        rend.material.SetTextureOffset(textureName, uvOffset);   
    }

    public void StopLavaMovement()
    {
        isLavaMoving = false;
    }

    public void ResumeLavaMovement()
    {
        isLavaMoving = true;
    }
}
