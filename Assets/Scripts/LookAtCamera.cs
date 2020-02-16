using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // разварачивать по позиции главной камеры
        transform.LookAt(Camera.main.transform);
    }
}
