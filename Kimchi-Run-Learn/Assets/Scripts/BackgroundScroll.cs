using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("How fast should the texture scroll?")]
    public float scrollSpeed;

    [Header("References")]
    public MeshRenderer meshRenderer;

    void Start() // ������Ʈ�� ���ʷ� ȣ��Ǳ� �� �ѹ��� ȣ��Ǵ� �޼ҵ�
    {
        
    }

    
    void Update() // ������ �� �� ���� ȣ��Ǵ� �޼ҵ�
    {
        meshRenderer.material.mainTextureOffset += new Vector2(scrollSpeed * Time.deltaTime, 0) ;
    }
}
