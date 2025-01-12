using UnityEngine;

public class Heart : MonoBehaviour
{
    public Sprite onHeart;
    public Sprite offHeart;
    public SpriteRenderer spriteRenderer;
    public int liveNumber;

    void Update()
    {
        // 플레이어의 Lives가 liveNumber보다 크거나 같으면 스프라이트를 onHeart로 변경 
        // 예를들어 liveNumber가 3으로 된 컴포넌트를 붙여놓은 스프라이트는 Lives가 2이면 offHeart가 된다.
        if (GameManager.Instance.Lives >= liveNumber)
        {
            spriteRenderer.sprite = onHeart;
        }
        else
        {
           spriteRenderer.sprite = offHeart;
        }
    }
}
