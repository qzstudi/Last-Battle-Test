using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class ResourceManager: MonoBehaviour
{

    static Dictionary<string,AssetBundle> m_BundleMap=new Dictionary<string, AssetBundle>();

    public AssetBundle LoadBundle(string name)
    {
        if(m_BundleMap.ContainsKey(name)&&m_BundleMap[name]!=null)
        {
            return m_BundleMap[name];
        }
        else{
            byte[] stream=null;
            AssetBundle bundle=null;
            string url = Util.DataPath+name.ToLower()+".assetbundle";
            stream=File.ReadAllBytes(url);
            bundle=AssetBundle.LoadFromMemory(stream);
            if(m_BundleMap.ContainsKey(name))
            {
                m_BundleMap[name]=bundle;
            }
            else
            {
                m_BundleMap.Add(name,bundle);
            }
            return bundle;
        }
    }
}