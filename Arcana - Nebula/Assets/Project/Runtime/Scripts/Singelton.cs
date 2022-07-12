using UnityEngine;

namespace ArcaneNebula
{
    public abstract class Singelton<T> : MonoBehaviour where T : Singelton<T>
    {
        public static T Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
                    if (gm)
                        s_Instance = gm.AddComponent<T>();
                    else
                    {
                        gm = new GameObject("GameManager");
                        gm.tag = "GameManager";
                        s_Instance = gm.AddComponent<T>();
                    }
                }

                return s_Instance;
            }
        }

        protected static T s_Instance;

        public virtual void Awake()
        {
            if (!s_Instance)
                s_Instance = (T)this;
            else Destroy(this);
        }
    }
}
