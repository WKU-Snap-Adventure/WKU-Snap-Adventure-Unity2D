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
    /// ��ʹ�� Physics.Raycast �������߼��ʱ����Ҫ���ݼ���������
        /*
        1. ray������Ҫ�������߼������߶�������ʾ�����ߵ����ͷ���

        2. hit������һ�� RaycastHit ���͵Ĳ��������ڴ洢���߼��Ľ������������볡���е������ཻ����ص���Ϣ���罻��λ�á����ߵȣ�����洢�� hit �����С�

        3. distance�����������ʾ���ߵ���󳤶ȣ��������ܹ���⵽����Զ���롣����ཻ���������������㳬��������룬�����߼�⽫���᷵���ཻ�Ľ����

        4. layerMask������һ����ʾ�㼶�Ĳ���������ָ�����߼��ʱ��Ҫ���ǵ�����㼶��ֻ����ָ���㼶�������н������߼�⣬�����ָ������������в㼶�����塣

        �ۺ�������Physics.Raycast �����ᷢ��һ�����ߣ�����Ƿ��볡���е������ཻ������ཻ�����ཻ����Ϣ�洢�� hit �����С�ͬʱ�����������ߵ���󳤶ȣ��Լ�ָ����Ҫ���ǵ�����㼶��*/
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
