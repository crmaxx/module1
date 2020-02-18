using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        // разварачивать по позиции главной камеры
        transform.LookAt(Camera.main.transform);
    }
}
