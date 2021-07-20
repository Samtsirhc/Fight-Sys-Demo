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
        //1.屏幕转世界坐标
        result = cam.ScreenToWorldPoint(test_vector);
        //2.世界转屏幕坐标
        result = cam.WorldToScreenPoint(test_vector);

        //视口坐标：View Port, 视口是针对游戏显示的画面进行描述的，View Port用于描述整个游戏画面的坐标，左下角为(0, 0),右上角为（1,1)，我们在设计分屏游戏的时候可以通过设置摄像机所占据的视口空间
        //3.世界转视口坐标
        result = cam.WorldToViewportPoint(test_vector);
        //4.视口转世界坐标
        result = cam.ViewportToWorldPoint(test_vector);

        // 屏幕坐标：Screen Space屏幕坐标开始和像素扯上关系了，也就是说屏幕坐标和分辨率有关，屏幕的左下角为(0, 0),但右上角为(screen.width, screen.height)。比如游戏的分辨率为500 * 600，则screen.width = 500; screen.height = 600。
        //5.视口转屏幕坐标
        result = cam.ViewportToScreenPoint(test_vector);
        //6.屏幕转视口坐标
        result = cam.ScreenToViewportPoint(test_vector);
    }
}
