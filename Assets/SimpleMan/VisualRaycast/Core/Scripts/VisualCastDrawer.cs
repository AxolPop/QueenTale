using System.Collections.Generic;
using UnityEngine;
using System;
using SimpleMan.Extensions;

namespace SimpleMan.VisualRaycast
{
    internal struct ColorPare
    {
        //******            PROPERTIES        	******\\
        public Color HitColor => _hitColor;
        public Color NoHitColor => _noHitColor;




        //******            FIELDS          	******\\
        private Color _hitColor;
        private Color _noHitColor;



        //******           CONSTRUCTORS         ******\\
        public ColorPare(Color hitColor, Color noHitColor)
        {
            _hitColor = hitColor;
            _noHitColor = noHitColor;
        }
    }


    internal class GizmoDrawState
    {
        //******            FIELDS          	******\\
        public float currentColorAlpha = 1;
        public float fadeTime;
        public Action<float> drawAction;




        //******           CONSTRUCTORS         ******\\
        public GizmoDrawState(float fadeTime, Action<float> drawAction)
        {
            this.drawAction = drawAction;
            this.fadeTime = fadeTime;
        }
    }

   
    [AddComponentMenu("Simple Man/Visual Raycast/Visual Raycast Drawer")]
    public class VisualCastDrawer : MonoBehaviour
    {
        //******            PROPERTIES        	******\\
        public static VisualCastDrawer Instance => _instance;
        public int MaxQueueSize
        {
            get => _maxQueueSize;
            set => _maxQueueSize = Mathf.Clamp(_maxQueueSize, 1, int.MaxValue);
        }



        //******            FIELDS          	******\\
        private static VisualCastDrawer _instance;
        private List<GizmoDrawState> _drawQueue = new List<GizmoDrawState>();
        private int _maxQueueSize = 25;
        private Coroutine _refreshQueueRepeater;


        [SerializeField]
        private bool _printLog = true;




        //******    	    METHODS  	  	    ******\\
        private void Awake()
        {
            if (_instance && _instance != this)
                Destroy(gameObject);

            _instance = this;
        }


        private void OnEnable()
        {
            _refreshQueueRepeater = this.RepeatForever(RefreshDrawQueue, 0.5f);
        }


        private void OnDisable()
        {
            if (_refreshQueueRepeater != null)
                StopCoroutine(_refreshQueueRepeater);
        }


        private void OnDrawGizmos()
        {
            foreach (var gizmoProcess in _drawQueue)
            {
                //Cache previous color
                Color previousColor = Gizmos.color;

                //Invoke draw action
                gizmoProcess.drawAction.Invoke(gizmoProcess.currentColorAlpha);

                //Decreace color alpha
                gizmoProcess.currentColorAlpha -= 1 / gizmoProcess.fadeTime * Time.deltaTime;

                //Reset color
                Gizmos.color = previousColor;
            }
        }


        internal void DrawRay(RaycastInfo info)
        {
            //Is queue full? -> Return
            if(_drawQueue.Count >= _maxQueueSize)
            {
                if(_printLog)
                    Debug.LogWarning($"<B> <color=#1272e0> Visual Cast: </color> </B> There is to many gizmos in draw queue. You can change max queue size in Visual Cast Drawer inspector");

                return;
            }


            //Create new state data about this gizmo
            GizmoDrawState currentGizmoDrawState = new GizmoDrawState(GetFadeTime(info), (float alpha) =>
            {
                ColorPare colorPare = GetColorPare(info);


                if (info.CastResult)
                {
                    //Set new color
                    Gizmos.color = new Color(colorPare.HitColor.r,
                                             colorPare.HitColor.g,
                                             colorPare.HitColor.b,
                                             alpha);


                    //Line from previous hit point to last hit
                    Gizmos.DrawLine(info.OriginPoint, info.CastResult.LastHit.point);



                    //Is using cast all? -> Draw additional gizmo 
                    if (info.CastResult.Hits.Length > 1)
                    {
                        //Set new color
                        Gizmos.color = new Color(colorPare.NoHitColor.r,
                                                 colorPare.NoHitColor.g,
                                                 colorPare.NoHitColor.b,
                                                 alpha);


                        //Line from origin to end point
                        Gizmos.DrawLine(info.CastResult.LastHit.point, info.CastResult.LastHit.point + info.Direction * (info.MaxDistance - info.CastResult.LastHit.distance));
                    }
                }
                else
                {
                    //Set no hitcolor
                    Gizmos.color = new Color(colorPare.NoHitColor.r,
                                             colorPare.NoHitColor.g,
                                             colorPare.NoHitColor.b,
                                             alpha);


                    //Line from origin point to end point
                    Gizmos.DrawLine(info.OriginPoint, info.OriginPoint + info.Direction * info.MaxDistance);
                }
            });


            //Add state data to drawing queue
            _drawQueue.Add(currentGizmoDrawState);
        }


        internal void DrawBox(BoxcastInfo info)
        {
            //Is queue full? -> Return
            if (_drawQueue.Count >= _maxQueueSize)
            {
                if(_printLog)
                    Debug.LogWarning($"<B> <color=#1272e0> Visual Cast: </color> </B> There is to many gizmos in draw queue. You can change max queue size in Visual Cast Drawer inspector");

                return;
            }


            //Create new state data about this gizmo
            GizmoDrawState currentGizmoDrawState = new GizmoDrawState(GetFadeTime(info), (float alpha) =>
            {
                void DrawCube(Vector3 center)
                {
                    Vector3 lineOrigin, lineEnd;


                    //Top front line
                    lineOrigin = lineEnd = center;
                    lineOrigin += info.Rotation * Vector3.up * info.Size.y * 0.5f +
                                  info.Rotation * Vector3.left * info.Size.x * 0.5f +
                                  info.Rotation * Vector3.back * info.Size.z * 0.5f;

                    lineEnd += info.Rotation * Vector3.up * info.Size.y * 0.5f +
                               info.Rotation * Vector3.right * info.Size.x * 0.5f +
                               info.Rotation * Vector3.back * info.Size.z * 0.5f;

                    Gizmos.DrawLine(lineOrigin, lineEnd);




                    //Top back line
                    lineOrigin = lineEnd = center;
                    lineOrigin += info.Rotation * Vector3.up * info.Size.y * 0.5f +
                                  info.Rotation * Vector3.left * info.Size.x * 0.5f +
                                  info.Rotation * Vector3.forward * info.Size.z * 0.5f;

                    lineEnd += info.Rotation * Vector3.up * info.Size.y * 0.5f +
                               info.Rotation * Vector3.right * info.Size.x * 0.5f +
                               info.Rotation * Vector3.forward * info.Size.z * 0.5f;

                    Gizmos.DrawLine(lineOrigin, lineEnd);




                    //Bottom front line
                    lineOrigin = lineEnd = center;
                    lineOrigin += info.Rotation * Vector3.down * info.Size.y * 0.5f +
                                  info.Rotation * Vector3.left * info.Size.x * 0.5f +
                                  info.Rotation * Vector3.forward * info.Size.z * 0.5f;

                    lineEnd += info.Rotation * Vector3.down * info.Size.y * 0.5f +
                               info.Rotation * Vector3.right * info.Size.x * 0.5f +
                               info.Rotation * Vector3.forward * info.Size.z * 0.5f;

                    Gizmos.DrawLine(lineOrigin, lineEnd);




                    //Bottom back line
                    lineOrigin = lineEnd = center;
                    lineOrigin += info.Rotation * Vector3.down * info.Size.y * 0.5f +
                                  info.Rotation * Vector3.left * info.Size.x * 0.5f +
                                  info.Rotation * Vector3.back * info.Size.z * 0.5f;

                    lineEnd += info.Rotation * Vector3.down * info.Size.y * 0.5f +
                               info.Rotation * Vector3.right * info.Size.x * 0.5f +
                               info.Rotation * Vector3.back * info.Size.z * 0.5f;

                    Gizmos.DrawLine(lineOrigin, lineEnd);




                    //Front left line
                    lineOrigin = lineEnd = center;
                    lineOrigin += info.Rotation * Vector3.up * info.Size.y * 0.5f +
                                  info.Rotation * Vector3.left * info.Size.x * 0.5f +
                                  info.Rotation * Vector3.back * info.Size.z * 0.5f;

                    lineEnd += info.Rotation * Vector3.down * info.Size.y * 0.5f +
                               info.Rotation * Vector3.left * info.Size.x * 0.5f +
                               info.Rotation * Vector3.back * info.Size.z * 0.5f;

                    Gizmos.DrawLine(lineOrigin, lineEnd);




                    //Back left line
                    lineOrigin = lineEnd = center;
                    lineOrigin += info.Rotation * Vector3.up * info.Size.y * 0.5f +
                                  info.Rotation * Vector3.left * info.Size.x * 0.5f +
                                  info.Rotation * Vector3.forward * info.Size.z * 0.5f;

                    lineEnd += info.Rotation * Vector3.down * info.Size.y * 0.5f +
                               info.Rotation * Vector3.left * info.Size.x * 0.5f +
                               info.Rotation * Vector3.forward * info.Size.z * 0.5f;

                    Gizmos.DrawLine(lineOrigin, lineEnd);




                    //Front right line
                    lineOrigin = lineEnd = center;
                    lineOrigin += info.Rotation * Vector3.up * info.Size.y * 0.5f +
                                  info.Rotation * Vector3.right * info.Size.x * 0.5f +
                                  info.Rotation * Vector3.forward * info.Size.z * 0.5f;

                    lineEnd += info.Rotation * Vector3.down * info.Size.y * 0.5f +
                               info.Rotation * Vector3.right * info.Size.x * 0.5f +
                               info.Rotation * Vector3.forward * info.Size.z * 0.5f;

                    Gizmos.DrawLine(lineOrigin, lineEnd);




                    //Back right line
                    lineOrigin = lineEnd = center;
                    lineOrigin += info.Rotation * Vector3.up * info.Size.y * 0.5f +
                                  info.Rotation * Vector3.right * info.Size.x * 0.5f +
                                  info.Rotation * Vector3.back * info.Size.z * 0.5f;

                    lineEnd += info.Rotation * Vector3.down * info.Size.y * 0.5f +
                               info.Rotation * Vector3.right * info.Size.x * 0.5f +
                               info.Rotation * Vector3.back * info.Size.z * 0.5f;

                    Gizmos.DrawLine(lineOrigin, lineEnd);




                    //Top left line
                    lineOrigin = lineEnd = center;
                    lineOrigin += info.Rotation * Vector3.up * info.Size.y * 0.5f +
                                  info.Rotation * Vector3.left * info.Size.x * 0.5f +
                                  info.Rotation * Vector3.back * info.Size.z * 0.5f;

                    lineEnd += info.Rotation * Vector3.up * info.Size.y * 0.5f +
                               info.Rotation * Vector3.left * info.Size.x * 0.5f +
                               info.Rotation * Vector3.forward * info.Size.z * 0.5f;

                    Gizmos.DrawLine(lineOrigin, lineEnd);




                    //Bottom left line
                    lineOrigin = lineEnd = center;
                    lineOrigin += info.Rotation * Vector3.down * info.Size.y * 0.5f +
                                  info.Rotation * Vector3.left * info.Size.x * 0.5f +
                                  info.Rotation * Vector3.back * info.Size.z * 0.5f;

                    lineEnd += info.Rotation * Vector3.down * info.Size.y * 0.5f +
                               info.Rotation * Vector3.left * info.Size.x * 0.5f +
                               info.Rotation * Vector3.forward * info.Size.z * 0.5f;

                    Gizmos.DrawLine(lineOrigin, lineEnd);




                    //Top right line
                    lineOrigin = lineEnd = center;
                    lineOrigin += info.Rotation * Vector3.up * info.Size.y * 0.5f +
                                  info.Rotation * Vector3.right * info.Size.x * 0.5f +
                                  info.Rotation * Vector3.back * info.Size.z * 0.5f;

                    lineEnd += info.Rotation * Vector3.up * info.Size.y * 0.5f +
                               info.Rotation * Vector3.right * info.Size.x * 0.5f +
                               info.Rotation * Vector3.forward * info.Size.z * 0.5f;

                    Gizmos.DrawLine(lineOrigin, lineEnd);




                    //Bottom right line
                    lineOrigin = lineEnd = center;
                    lineOrigin += info.Rotation * Vector3.down * info.Size.y * 0.5f +
                                  info.Rotation * Vector3.right * info.Size.x * 0.5f +
                                  info.Rotation * Vector3.back * info.Size.z * 0.5f;

                    lineEnd += info.Rotation * Vector3.down * info.Size.y * 0.5f +
                               info.Rotation * Vector3.right * info.Size.x * 0.5f +
                               info.Rotation * Vector3.forward * info.Size.z * 0.5f;

                    Gizmos.DrawLine(lineOrigin, lineEnd);
                }
                ColorPare colorPare = GetColorPare(info);


                if (info.CastResult)
                {
                    //Set hit color
                    Gizmos.color = new Color(colorPare.HitColor.r,
                                             colorPare.HitColor.g,
                                             colorPare.HitColor.b,
                                             alpha);


                    //Line from origin to last hit
                    Gizmos.DrawLine(info.OriginPoint, info.OriginPoint + info.Direction * info.CastResult.LastHit.distance);


                    //Draw box
                    DrawCube(info.OriginPoint + info.Direction * info.CastResult.LastHit.distance);


                    //Set no hit color
                    Gizmos.color = new Color(colorPare.NoHitColor.r,
                                             colorPare.NoHitColor.g,
                                             colorPare.NoHitColor.b,
                                             alpha);


                    //Is using cast all? -> Draw additional gizmo 
                    if (info.CastResult.Hits.Length > 1)
                    {
                        //Line from last hit to max distance point
                        Gizmos.DrawLine(info.OriginPoint + info.Direction * info.CastResult.LastHit.distance, info.OriginPoint + info.Direction * info.MaxDistance);


                        //Draw box
                        DrawCube(info.OriginPoint + info.Direction * info.MaxDistance);
                    }
                }
                else
                {
                    //Set no hit color
                    Gizmos.color = new Color(colorPare.NoHitColor.r,
                                             colorPare.NoHitColor.g,
                                             colorPare.NoHitColor.b,
                                             alpha);


                    //Line from origin to center of the box
                    Gizmos.DrawLine(info.OriginPoint, info.OriginPoint + info.Direction * info.MaxDistance);


                    //Draw cube
                    DrawCube(info.OriginPoint + info.Direction * info.MaxDistance);
                }
            });


            //Add state data to drawing queue 
            _drawQueue.Add(currentGizmoDrawState);
        }


        internal void DrawSphere(SpherecastInfo info)
        {
            //Is queue full? -> Return
            if (_drawQueue.Count >= _maxQueueSize)
            {
                if(_printLog)
                    Debug.LogWarning($"<B> <color=#1272e0> Visual Cast: </color> </B> There is to many gizmos in draw queue. You can change max queue size in Visual Cast Drawer inspector");

                return;
            }


            ColorPare colorPare = GetColorPare(info);


            //Create new state data about this gizmo
            GizmoDrawState currentGizmoDrawState = new GizmoDrawState(GetFadeTime(info), (float alpha) =>
            {
                if (info.CastResult)
                {
                    //Set hit color
                    Gizmos.color = new Color(colorPare.HitColor.r,
                                             colorPare.HitColor.g,
                                             colorPare.HitColor.b,
                                             alpha);


                    //Line from origin to last hit
                    Gizmos.DrawLine(info.OriginPoint, info.OriginPoint + info.Direction * info.CastResult.LastHit.distance);


                    //Draw sphere
                    Gizmos.DrawWireSphere(info.OriginPoint + info.Direction * info.CastResult.LastHit.distance, info.Radius);


                    //Set no hit color
                    Gizmos.color = new Color(colorPare.NoHitColor.r,
                                             colorPare.NoHitColor.g,
                                             colorPare.NoHitColor.b,
                                             alpha);


                    //Is using cast all? -> Draw additional gizmo 
                    if (info.CastResult.Hits.Length > 1)
                    {
                        //Line from last hit to max distance point
                        Gizmos.DrawLine(info.OriginPoint + info.Direction * info.CastResult.LastHit.distance, info.OriginPoint + info.Direction * info.MaxDistance);


                        //Draw sphere
                        Gizmos.DrawWireSphere(info.OriginPoint + info.Direction * info.MaxDistance, info.Radius);
                    }
                }
                else
                {
                    //Set no hit color
                    Gizmos.color = new Color(colorPare.NoHitColor.r,
                                             colorPare.NoHitColor.g,
                                             colorPare.NoHitColor.b,
                                             alpha);


                    //Line from origin to max distance
                    Gizmos.DrawLine(info.OriginPoint, info.OriginPoint + info.Direction * info.MaxDistance);


                    //Draw sphere
                    Gizmos.DrawWireSphere(info.OriginPoint + info.Direction * info.MaxDistance, info.Radius);
                    
                }
            });


            //Add state data to drawing queue
            _drawQueue.Add(currentGizmoDrawState);
        }


        private ColorPare GetColorPare(CastInfo info)
        {
            if (info.CustomParams != null)
                return new ColorPare(info.CustomParams.HitColor, info.CustomParams.NoHitColor);

            else
                return new ColorPare(Preferences.HitColor, Preferences.NoHitColor);
        }


        private float GetFadeTime(CastInfo info)
        {
            //Is Preferences overwrited? -> Use custom fade time
            if (info.CustomParams != null)
                return info.CustomParams.FadeTime;

            else
                return Preferences.FadeTime;
        }


        private void RefreshDrawQueue()
        {
            for (int i = 0; i < _drawQueue.Count; i++)
            {
                if (_drawQueue[i].currentColorAlpha <= 0)
                    _drawQueue.RemoveAt(i);
            }
        }
    }
}