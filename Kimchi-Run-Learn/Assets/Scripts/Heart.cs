using UnityEngine;

public class Heart : MonoBehaviour
{
    public Sprite onHeart;
    public Sprite offHeart;
    public SpriteRenderer spriteRenderer;
    public int liveNumber;

    void Update()
    {
        // �÷��̾��� Lives�� liveNumber���� ũ�ų� ������ ��������Ʈ�� onHeart�� ���� 
        // ������� liveNumber�� 3���� �� ������Ʈ�� �ٿ����� ��������Ʈ�� Lives�� 2�̸� offHeart�� �ȴ�.
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
