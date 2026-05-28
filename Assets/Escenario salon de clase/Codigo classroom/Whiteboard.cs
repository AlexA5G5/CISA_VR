using UnityEngine;

public class Whiteboard : MonoBehaviour
{
    public Texture2D texture;
    public Vector2 textureSize = new Vector2(2048, 2048);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var r = GetComponent<Renderer>();
        texture = new Texture2D(width: (int)textureSize.x, (int)textureSize.y);
        r.material.mainTexture = texture;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
