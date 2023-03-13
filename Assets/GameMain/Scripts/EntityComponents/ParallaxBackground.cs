using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityGameFramework.Scripts.Runtime.EntityComponents
{

    public class ParallaxBackground : MonoBehaviour
    {
        private Transform mainCameraTransform;//主相机的transform
        private Vector3 lastCameraPosition;//记录主相机上一帧的位置
        private float textureUnitSizeX;//获得背景图在项目中的单位长度

        public Vector2 bgMoveCoefficient;//背景相对于主相机移动长度系数

        // Start is called before the first frame update
        void Start()
        {
            Sprite sprite = GetComponent<SpriteRenderer>().sprite;
            Texture2D texture = sprite.texture;
            textureUnitSizeX = texture.width / sprite.pixelsPerUnit;//计算出纹理占多少个单位长度
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void LateUpdate()
        {
            
        }
    }

}