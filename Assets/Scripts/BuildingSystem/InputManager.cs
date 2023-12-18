using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private Camera sceneCamera;

    private Vector3 lastPosition;
    [SerializeField]
    private LayerMask placementLayermask;
    public event Action OnClicked, OnExit;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            OnClicked?.Invoke();
        if (Input.GetKeyDown(KeyCode.Escape))
            OnExit?.Invoke();
    }
    public bool IsPointerOverUI() => EventSystem.current.IsPointerOverGameObject();

    /// <summary>
    /// 当使用 Physics.Raycast 进行射线检测时，需要传递几个参数：
        /*
        1. ray：这是要进行射线检测的射线对象，它表示了射线的起点和方向。

        2. hit：这是一个 RaycastHit 类型的参数，用于存储射线检测的结果。如果射线与场景中的物体相交，相关的信息（如交点位置、法线等）将会存储在 hit 对象中。

        3. distance：这个参数表示射线的最大长度，即射线能够检测到的最远距离。如果相交的物体距离射线起点超过这个距离，则射线检测将不会返回相交的结果。

        4. layerMask：这是一个表示层级的参数，用于指定射线检测时需要考虑的物体层级。只有在指定层级的物体中进行射线检测，如果不指定，则会检测所有层级的物体。

        综合起来，Physics.Raycast 函数会发射一条射线，检测是否与场景中的物体相交，如果相交，则将相交的信息存储在 hit 对象中。同时可以限制射线的最大长度，以及指定需要考虑的物体层级。*/
    /// </summary>
    /// <returns></returns>
    public Vector2 GetSelectedMapPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -sceneCamera.transform.position.z;
        Vector2 lastPosition = sceneCamera.ScreenToWorldPoint(mousePos);

        RaycastHit2D hit = Physics2D.Raycast(lastPosition, Vector2.zero, Mathf.Infinity, placementLayermask);
        if (hit.collider != null)
        {
            lastPosition = hit.point;
        }

        return lastPosition;
    }
}
