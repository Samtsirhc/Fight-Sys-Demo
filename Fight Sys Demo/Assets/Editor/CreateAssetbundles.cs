using UnityEditor;
using System.IO;


public class CreateAssetbundles
{

    [MenuItem("AssetsBundle/Build AssetBundles")]
    static void BuildAllAssetBundles()//���д��
    {
        string dir = "AssetBundles";
        //�жϸ�Ŀ¼�Ƿ����
        if (Directory.Exists(dir) == false)
        {
            Directory.CreateDirectory(dir);//�ڹ����´���AssetBundlesĿ¼
        }
        //����һΪ������ĸ�·����������ѹ��ѡ��  ������ ƽ̨��Ŀ��
        BuildPipeline.BuildAssetBundles(dir, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
    }
}
