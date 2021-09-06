using UnityEngine;


namespace SimpleMan.VisualRaycast
{
    internal abstract class CastInfo
    {
        //******            PROPERTIES        	******\\
        public Vector3 OriginPoint => _originPoint;
        public Vector3 Direction => _direction;
        public CastResult CastResult => _castResult;
        public CustomParams CustomParams => _customParams;
        public float MaxDistance => _maxDistance;
        



        //******            FIELDS          	******\\
        protected Vector3 _originPoint;
        protected Vector3 _direction;
        protected float _maxDistance;
        protected CastResult _castResult;
        protected CustomParams _customParams;
    }


    internal sealed class RaycastInfo : CastInfo
    {
        //******            PROPERTIES        	******\\





        //******            FIELDS          	******\\





        //******           CONSTRUCTORS         ******\\
        public RaycastInfo(Vector3 originPoint, Vector3 direction, float maxDistance, CastResult castResult, CustomParams customParams)
        {
            _originPoint = originPoint;
            _direction = direction;
            _maxDistance = maxDistance;
            _castResult = castResult;
            _customParams = customParams;
        }
    }


    internal sealed class SpherecastInfo : CastInfo
    {
        //******            PROPERTIES        	******\\
        public float Radius => _radius;




        //******            FIELDS          	******\\
        private float _radius;




        //******           CONSTRUCTORS         ******\\
        public SpherecastInfo(Vector3 originPoint, Vector3 direction, float radius, float maxDistance, CastResult castResult, CustomParams customParams)
        {
            _originPoint = originPoint;
            _direction = direction;
            _radius = radius;
            _maxDistance = maxDistance;
            _castResult = castResult;
            _customParams = customParams;
        }
    }


    internal sealed class BoxcastInfo : CastInfo
    {
        //******            PROPERTIES        	******\\
        public Vector3 Size => _size;
        public Quaternion Rotation => _rotation;




        //******            FIELDS          	******\\
        private Vector3 _size;
        private Quaternion _rotation;



        //******           CONSTRUCTORS         ******\\
        public BoxcastInfo(Vector3 originPoint, Vector3 direction, Vector3 size, Quaternion rotation, float maxDistance, CastResult castResult, CustomParams customParams)
        {
            _originPoint = originPoint;
            _direction = direction;
            _size = size;
            _rotation = rotation;
            _maxDistance = maxDistance;
            _castResult = castResult;
            _customParams = customParams;
        }
    }
}