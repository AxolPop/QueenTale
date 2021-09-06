using UnityEngine;


namespace SimpleMan.VisualRaycast
{
    public class VisualCast
    {
        #region RAYCAST
        /// <summary>
        /// Make raycast 
        /// </summary>
        /// <param name="originPoint"></param>
        /// <param name="direction"></param>
        /// <param name="maxDistance"></param>
        /// <param name="drawGizmo">Should the gizmo be drawn?</param>
        /// <param name="customParams">Custom draw parameters. If this value is null, the gizmo will be drawn with default parameters</param>
        /// <returns></returns>
        public static CastResult Raycast(Vector3 originPoint, Vector3 direction, float maxDistance, bool drawGizmo = true, CustomParams customParams = null)
        {
            CastResult castResult = new CastResult();
            RaycastHit hit;


            //Hit something? => Add hit as result
            if (Physics.Raycast(originPoint, direction, out hit, maxDistance))
                castResult = new CastResult(hit);


            //Draw gizmo if need
            if (drawGizmo)
            {
                UpdateDrawerOnScene();

                RaycastInfo info = new RaycastInfo(originPoint, direction, maxDistance, castResult, customParams);
                VisualCastDrawer.Instance.DrawRay(info);
            }


            //Return empty cast result
            return castResult;
        }


        /// <summary>
        /// Make raycast
        /// </summary>
        /// <param name="originPoint"></param>
        /// <param name="direction"></param>
        /// <param name="maxDistance"></param>
        /// <param name="layerMask"></param>
        /// <param name="drawGizmo">Should the gizmo be drawn?</param>
        /// <param name="customParams">Custom draw parameters. If this value is null, the gizmo will be drawn with default parameters</param>
        /// <returns></returns>
        public static CastResult Raycast(Vector3 originPoint, Vector3 direction, float maxDistance, LayerMask layerMask, bool drawGizmo = true, CustomParams customParams = null)
        {
            CastResult castResult = new CastResult();
            RaycastHit hit;


            //Hit something? => Add hit as result
            if (Physics.Raycast(originPoint, direction, out hit, maxDistance, layerMask))
                castResult = new CastResult(hit);


            //Draw gizmo if need
            if (drawGizmo)
            {
                UpdateDrawerOnScene();

                RaycastInfo info = new RaycastInfo(originPoint, direction, maxDistance, castResult, customParams);
                VisualCastDrawer.Instance.DrawRay(info);
            }


            //Return empty cast result
            return castResult;
        }


        /// <summary>
        /// Make raycast 
        /// </summary>
        /// <param name="originPoint"></param>
        /// <param name="direction"></param>
        /// <param name="maxDistance"></param>
        /// <param name="drawGizmo">Should the gizmo be drawn?</param>
        /// <param name="customParams">Custom draw parameters. If this value is null, the gizmo will be drawn with default parameters</param>
        /// <returns></returns>
        public static CastResult RaycastAll(Vector3 originPoint, Vector3 direction, float maxDistance, bool drawGizmo = true, CustomParams customParams = null)
        {
            //Hit something? => Add hit as result
            RaycastHit[] hits = Physics.RaycastAll(originPoint, direction, maxDistance);
            CastResult castResult = new CastResult(hits);


            //Draw gizmo if need
            if (drawGizmo)
            {
                UpdateDrawerOnScene();

                RaycastInfo info = new RaycastInfo(originPoint, direction, maxDistance, castResult, customParams);
                VisualCastDrawer.Instance.DrawRay(info);
            }


            //Return empty cast result
            return castResult;
        }


        /// <summary>
        /// Make raycast 
        /// </summary>
        /// <param name="originPoint"></param>
        /// <param name="direction"></param>
        /// <param name="maxDistance"></param>
        /// <param name="drawGizmo">Should the gizmo be drawn?</param>
        /// <param name="customParams">Custom draw parameters. If this value is null, the gizmo will be drawn with default parameters</param>
        /// <returns></returns>
        public static CastResult RaycastAll(Vector3 originPoint, Vector3 direction, float maxDistance, LayerMask layerMask, bool drawGizmo = true, CustomParams customParams = null)
        {
            //Hit something? => Add hit as result
            RaycastHit[] hits = Physics.RaycastAll(originPoint, direction, maxDistance, layerMask);
            CastResult castResult = new CastResult(hits);


            //Draw gizmo if need
            if (drawGizmo)
            {
                UpdateDrawerOnScene();

                RaycastInfo info = new RaycastInfo(originPoint, direction, maxDistance, castResult, customParams);
                VisualCastDrawer.Instance.DrawRay(info);
            }


            //Return empty cast result
            return castResult;
        }
        #endregion


        #region BOXCAST
        /// <summary>
        /// Make boxcast
        /// </summary>
        /// <param name="originPoint"></param>
        /// <param name="direction"></param>
        /// <param name="size"></param>
        /// <param name="maxDistance"></param>
        /// <param name="rotation"></param>
        /// <param name="drawGizmo"></param>
        /// <param name="customParams">Custom draw parameters. If this value is null, the gizmo will be drawn with default parameters</param>
        /// <returns></returns>
        public static CastResult Boxcast(Vector3 originPoint, Vector3 direction, Vector3 size, float maxDistance, Quaternion rotation, bool drawGizmo = true, CustomParams customParams = null)
        {
            CastResult castResult = new CastResult();
            RaycastHit hit;


            //Hit something? => Add hit as result
            if (Physics.BoxCast(originPoint, size * 0.5f, direction, out hit, rotation, maxDistance)) 
                castResult = new CastResult(hit);


            //Draw gizmo if need
            if (drawGizmo)
            {
                UpdateDrawerOnScene();

                BoxcastInfo info = new BoxcastInfo(originPoint, direction, size, rotation, maxDistance, castResult, customParams);
                VisualCastDrawer.Instance.DrawBox(info);
            }


            //Return empty cast result
            return castResult;
        }

        /// <summary>
        /// Make boxcast
        /// </summary>
        /// <param name="originPoint"></param>
        /// <param name="direction"></param>
        /// <param name="size"></param>
        /// <param name="maxDistance"></param>
        /// <param name="rotation"></param>
        /// <param name="layerMask"></param>
        /// <param name="drawGizmo"></param>
        /// <param name="customParams">Custom draw parameters. If this value is null, the gizmo will be drawn with default parameters</param>
        /// <returns></returns>
        public static CastResult Boxcast(Vector3 originPoint, Vector3 direction, Vector3 size, float maxDistance, Quaternion rotation, LayerMask layerMask, bool drawGizmo = true, CustomParams customParams = null)
        {
            CastResult castResult = new CastResult();
            RaycastHit hit;


            //Hit something? => Add hit as result
            if (Physics.BoxCast(originPoint, size * 0.5f, direction, out hit, rotation, maxDistance, layerMask))
                castResult = new CastResult(hit);


            //Draw gizmo if need
            if (drawGizmo)
            {
                UpdateDrawerOnScene();

                BoxcastInfo info = new BoxcastInfo(originPoint, direction, size, rotation, maxDistance, castResult, customParams);
                VisualCastDrawer.Instance.DrawBox(info);
            }


            //Return empty cast result
            return castResult;
        }

        /// <summary>
        /// Make boxcast
        /// </summary>
        /// <param name="originPoint"></param>
        /// <param name="direction"></param>
        /// <param name="size"></param>
        /// <param name="maxDistance"></param>
        /// <param name="rotation"></param>
        /// <param name="drawGizmo"></param>
        /// <param name="customParams">Custom draw parameters. If this value is null, the gizmo will be drawn with default parameters</param>
        /// <returns></returns>
        public static CastResult BoxcastAll(Vector3 originPoint, Vector3 direction, Vector3 size, float maxDistance, Quaternion rotation, bool drawGizmo = true, CustomParams customParams = null)
        {
            //Hit something? => Add hit as result
            RaycastHit[] hits = Physics.BoxCastAll(originPoint, size * 0.5f, direction, rotation, maxDistance);
            CastResult castResult = new CastResult(hits);


            //Draw gizmo if need
            if (drawGizmo)
            {
                UpdateDrawerOnScene();


                BoxcastInfo info = new BoxcastInfo(originPoint, direction, size, rotation, maxDistance, castResult, customParams);
                VisualCastDrawer.Instance.DrawBox(info);
            }


            //Return empty cast result
            return castResult;
        }

        /// <summary>
        /// Make boxcast
        /// </summary>
        /// <param name="originPoint"></param>
        /// <param name="direction"></param>
        /// <param name="size"></param>
        /// <param name="maxDistance"></param>
        /// <param name="rotation"></param>
        /// <param name="drawGizmo"></param>
        /// <param name="customParams">Custom draw parameters. If this value is null, the gizmo will be drawn with default parameters</param>
        /// <returns></returns>
        public static CastResult BoxcastAll(Vector3 originPoint, Vector3 direction, Vector3 size, float maxDistance, Quaternion rotation, LayerMask layerMask, bool drawGizmo = true, CustomParams customParams = null)
        {
            //Hit something? => Add hit as result
            RaycastHit[] hits = Physics.BoxCastAll(originPoint, size * 0.5f, direction, rotation, maxDistance, layerMask);
            CastResult castResult = new CastResult(hits);


            //Draw gizmo if need
            if (drawGizmo)
            {
                UpdateDrawerOnScene();


                BoxcastInfo info = new BoxcastInfo(originPoint, direction, size, rotation, maxDistance, castResult, customParams);
                VisualCastDrawer.Instance.DrawBox(info);
            }


            //Return empty cast result
            return castResult;
        }
        #endregion


        #region SPHERECAST
        /// <summary>
        /// Make spherecast
        /// </summary>
        /// <param name="originPoint"></param>
        /// <param name="direction"></param>
        /// <param name="radius"></param>
        /// <param name="maxDistance"></param>
        /// <param name="drawGizmo"></param>
        /// <param name="customParams">Custom draw parameters. If this value is null, the gizmo will be drawn with default parameters</param>
        /// <returns></returns>
        public static CastResult Spherecast(Vector3 originPoint, Vector3 direction, float radius, float maxDistance, bool drawGizmo = true, CustomParams customParams = null)
        {
            CastResult castResult = new CastResult();
            RaycastHit hit;


            //Hit something? => Add hit as result
            if (Physics.SphereCast(originPoint, radius, direction, out hit, maxDistance))
                castResult = new CastResult(hit);


            //Draw gizmo if need
            if (drawGizmo)
            {
                UpdateDrawerOnScene();


                SpherecastInfo info = new SpherecastInfo(originPoint, direction, radius, maxDistance, castResult, customParams);
                VisualCastDrawer.Instance.DrawSphere(info);
            }


            //Return empty cast result
            return castResult;
        }

        /// <summary>
        /// Make spherecast
        /// </summary>
        /// <param name="originPoint"></param>
        /// <param name="direction"></param>
        /// <param name="radius"></param>
        /// <param name="maxDistance"></param>
        /// <param name="layerMask"></param>
        /// <param name="drawGizmo"></param>
        /// <param name="customParams">Custom draw parameters. If this value is null, the gizmo will be drawn with default parameters</param>
        /// <returns></returns>
        public static CastResult Spherecast(Vector3 originPoint, Vector3 direction, float radius, float maxDistance, LayerMask layerMask, bool drawGizmo = true, CustomParams customParams = null)
        {
            CastResult castResult = new CastResult();
            RaycastHit hit;


            //Hit something? => Add hit as result
            if (Physics.SphereCast(originPoint, radius, direction, out hit, maxDistance, layerMask))
                castResult = new CastResult(hit);


            //Draw gizmo if need
            if (drawGizmo)
            {
                UpdateDrawerOnScene();


                SpherecastInfo info = new SpherecastInfo(originPoint, direction, radius, maxDistance, castResult, customParams);
                VisualCastDrawer.Instance.DrawSphere(info);
            }


            //Return empty cast result
            return castResult;
        }

        /// <summary>
        /// Make spherecast
        /// </summary>
        /// <param name="originPoint"></param>
        /// <param name="direction"></param>
        /// <param name="radius"></param>
        /// <param name="maxDistance"></param>
        /// <param name="drawGizmo"></param>
        /// <param name="customParams">Custom draw parameters. If this value is null, the gizmo will be drawn with default parameters</param>
        /// <returns></returns>
        public static CastResult SpherecastAll(Vector3 originPoint, Vector3 direction, float radius, float maxDistance, bool drawGizmo = true, CustomParams customParams = null)
        {

            //Hit something? => Add hit as result
            RaycastHit[] hits = Physics.SphereCastAll(originPoint, radius, direction, maxDistance);
            CastResult castResult = new CastResult(hits);


            //Draw gizmo if need
            if (drawGizmo)
            {
                UpdateDrawerOnScene();


                SpherecastInfo info = new SpherecastInfo(originPoint, direction, radius, maxDistance, castResult, customParams);
                VisualCastDrawer.Instance.DrawSphere(info);
            }


            //Return empty cast result
            return castResult;
        }

        /// <summary>
        /// Make spherecast
        /// </summary>
        /// <param name="originPoint"></param>
        /// <param name="direction"></param>
        /// <param name="radius"></param>
        /// <param name="maxDistance"></param>
        /// <param name="drawGizmo"></param>
        /// <param name="customParams">Custom draw parameters. If this value is null, the gizmo will be drawn with default parameters</param>
        /// <returns></returns>
        public static CastResult SpherecastAll(Vector3 originPoint, Vector3 direction, float radius, float maxDistance, LayerMask layerMask, bool drawGizmo = true, CustomParams customParams = null)
        {

            //Hit something? => Add hit as result
            RaycastHit[] hits = Physics.SphereCastAll(originPoint, radius, direction, maxDistance, layerMask);
            CastResult castResult = new CastResult(hits);


            //Draw gizmo if need
            if (drawGizmo)
            {
                UpdateDrawerOnScene();


                SpherecastInfo info = new SpherecastInfo(originPoint, direction, radius, maxDistance, castResult, customParams);
                VisualCastDrawer.Instance.DrawSphere(info);
            }


            //Return empty cast result
            return castResult;
        }
        #endregion



        private static void UpdateDrawerOnScene()
        {
            if (VisualCastDrawer.Instance)
                return;


            GameObject drawer = new GameObject("VisualCastDrawer", typeof(VisualCastDrawer));
        }
    }
}