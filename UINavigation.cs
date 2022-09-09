
using System;
using UnityEngine;

namespace UnityGameUI
{
    // : MonoBehaviour
    public static class UINavigation
    {
        #region[全局参数]

        public static GameObject panel;   // 父级
        private static Navigation[] navigations;   // 导航列表
        private static int elementX;    // 元素X轴坐标
        private static int elementY;    // 元素Y轴坐标
        #endregion

        static UINavigation()
        {

        }

        public static void Initialize(Navigation[] nav, GameObject panel)
        {
            navigations = nav;
            UINavigation.panel = panel;

            elementX = (int)(-panel.GetComponent<RectTransform>().rect.width / 2 + 60);
            elementY = (int)(panel.GetComponent<RectTransform>().rect.height / 2 - 40);


            // 创建导航
            CreateNavigation();
        }

        // 创建导航栏
        public static void CreateNavigation()
        {
            foreach (var item in navigations)
            {
                string backgroundColor = "#8C9EFFFF";
                Vector3 localPosition = new Vector3(elementX, elementY, 0);
                UIControls.createUIButton(panel, backgroundColor, item.button, item.SetActive, localPosition);

                item.SetActive(item.show);

                elementY -= 60;

            }
        }

        public static void SetActive(this Navigation nav)
        {
            foreach (Navigation n in navigations)
            {
                if (n == nav)
                {
                    n.SetActive(true);
                }
                else
                {
                    n.SetActive(false);
                }
            }

        }
    }

    public class Navigation
    {
        public string key;          // 关键字        
        public string button;       // 按钮
        public GameObject panel;    // 面板
        public bool show;           // 是否显示

        public Navigation(string key, string button, GameObject panel, bool show)
        {
            this.key = key;
            this.button = button;
            this.panel = panel;
            this.show = show;
        }

        internal void SetActive(bool v)
        {
            show = v;
            panel.SetActive(v);
        }
    }
}
