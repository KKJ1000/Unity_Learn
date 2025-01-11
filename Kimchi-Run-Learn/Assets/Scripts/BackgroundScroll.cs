using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("How fast should the texture scroll?")]
    public float scrollSpeed;

    [Header("References")]
    public MeshRenderer meshRenderer;

    void Start() // 업데이트가 최초로 호출되기 전 한번만 호출되는 메소드
    {
        
    }

    
    void Update() // 프레임 당 한 번씩 호출되는 메소드
    {
        meshRenderer.material.mainTextureOffset += new Vector2(scrollSpeed * Time.deltaTime, 0) ;
    }
}
