using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateTransform : MonoBehaviour
{
    void Test()
    {
        Camera cam;
        cam = Camera.main;
        Vector3 test_vector = new Vector3(1, 1, 1);
        Vector3 result;
        //1.��Ļת��������
        result = cam.ScreenToWorldPoint(test_vector);
        //2.����ת��Ļ����
        result = cam.WorldToScreenPoint(test_vector);

        //�ӿ����꣺View Port, �ӿ��������Ϸ��ʾ�Ļ�����������ģ�View Port��������������Ϸ��������꣬���½�Ϊ(0, 0),���Ͻ�Ϊ��1,1)����������Ʒ�����Ϸ��ʱ�����ͨ�������������ռ�ݵ��ӿڿռ�
        //3.����ת�ӿ�����
        result = cam.WorldToViewportPoint(test_vector);
        //4.�ӿ�ת��������
        result = cam.ViewportToWorldPoint(test_vector);

        // ��Ļ���꣺Screen Space��Ļ���꿪ʼ�����س��Ϲ�ϵ�ˣ�Ҳ����˵��Ļ����ͷֱ����йأ���Ļ�����½�Ϊ(0, 0),�����Ͻ�Ϊ(screen.width, screen.height)��������Ϸ�ķֱ���Ϊ500 * 600����screen.width = 500; screen.height = 600��
        //5.�ӿ�ת��Ļ����
        result = cam.ViewportToScreenPoint(test_vector);
        //6.��Ļת�ӿ�����
        result = cam.ScreenToViewportPoint(test_vector);
    }
}
