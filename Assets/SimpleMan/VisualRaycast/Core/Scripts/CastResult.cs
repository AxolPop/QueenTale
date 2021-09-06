using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleMan.VisualRaycast
{

    public class CastResult
    {
        //******            PROPERTIES        	******\\
        public RaycastHit[] Hits => m_hits;
        public RaycastHit FirstHit
        {
            get
            {
                if (Hits.Length > 0)
                    return Hits[0];

                else
                    return new RaycastHit();
            }
        }
        public RaycastHit LastHit
        {
            get
            {
                if (Hits.Length > 0)
                    return Hits[Hits.Length - 1];

                else
                    return new RaycastHit();
            }
        }




        //******            FIELDS          	******\\
        private RaycastHit[] m_hits = new RaycastHit[] { };




        //******           CONSTRUCTORS         ******\\

        public CastResult(params RaycastHit[] hits)
        {
            m_hits = hits;
        }



        public static bool operator true(CastResult _castResult) => _castResult.Hits.Length > 0;


        public static bool operator false(CastResult _castResult) => _castResult.Hits.Length == 0;


        public static bool operator !(CastResult _castResult) => _castResult.Hits.Length == 0;

    }
}
