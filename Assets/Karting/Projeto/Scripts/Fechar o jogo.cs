using UnityEngine;

public class Fecharojogo : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            fechar();
        }
    }
    public void fechar()
    {
        Application.Quit();
    }
}
