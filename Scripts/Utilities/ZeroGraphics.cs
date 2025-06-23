using UnityEngine;
using UnityEngine.UI;

namespace Nrasix.SimpleTabSystem.Utilities
{
    [RequireComponent(typeof(CanvasRenderer))]
    public class ZeroGraphics : Graphic
    {
        protected override void OnPopulateMesh(VertexHelper vertexHelper) {}
        public override void SetMaterialDirty() {}
        public override void SetVerticesDirty() {}
    }
}