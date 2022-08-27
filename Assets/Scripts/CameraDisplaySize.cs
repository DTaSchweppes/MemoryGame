using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DTaSchweppes.Tools
{
 public class CameraDisplaySize : MonoBehaviour
 {
	private const float SizeX = 1920.0f; //размер дисплея по X
    private const float SizeY = 1080.0f; // размер дисплея по Y
    private const float HalfSize = 200.0f; // половина высоты в пикселях
    [SerializeField] private bool _isHorizontal = true;//Горизонтальная или вертикальная игра
    private float _targetSizeX = 0f; //После отработки методов значения сюда сохран
    private float _targetSizeY = 0f;

     private void Awake()
            {
                _targetSizeX = _isHorizontal ? SizeX : SizeY;//Если isHor true то x = sizex, иначе переворачиваем экран
                _targetSizeY = _isHorizontal ? SizeY : SizeX;

                ResizeCamera();
            }
    private void ResizeCamera()
            {
                float screenRatio = (float)Screen.width / (float)Screen.height;
                float targetRatio = _targetSizeX / _targetSizeY;

                if (screenRatio >= targetRatio)
                {
                    Resize();
                }
                else
                {
                    float differentSize = targetRatio / screenRatio;
                    Resize(differentSize);
                }
            }
    private void Resize(float differentSize = 1.0f)
            {
                Camera.main.orthographicSize = _targetSizeY / HalfSize * differentSize;
            }
    #if UNITY_EDITOR
            [ContextMenu("Resize")]
            private void ResizeOnEditor()
            {
                float higth = _isHorizontal ? SizeY : SizeX;
                Camera.main.orthographicSize = higth / HalfSize;
            }
    #endif
 }
}