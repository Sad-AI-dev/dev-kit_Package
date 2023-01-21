using UnityEngine;

namespace DevKit {
    [AddComponentMenu("DevKit/Utils/Message Debugger")]
    public class MessageDebugger : MonoBehaviour
    {
        public void DebugMessage(string msg)
        {
            Debug.Log(transform.name + ": " + msg);
        }

        //---------------value debugging------------------
        public void DebugMessage(MonoBehaviour behaviour)
        {
            DebugMessage(behaviour as Object);
        }

        public void DebugMessage(Object obj)
        {
            Debug.Log(transform.name + " reported value: " + obj.name);
        }

        //---common num types---
        public void DebugMessage(int i)
        {
            DebugMessageGeneric(i);
        }
        public void DebugMessage(float f)
        {
            DebugMessageGeneric(f);
        }
        public void DebugMessage(double d)
        {
            DebugMessageGeneric(d);
        }

        public void DebugMessage(Vector2 v)
        {
            DebugMessageGeneric(v);
        }
        public void DebugMessage(Vector3 v)
        {
            DebugMessageGeneric(v);
        }

        //---other common types---
        public void DebugMessage(bool b)
        {
            DebugMessageGeneric(b);
        }

        public void DebugMessage(char c)
        {
            DebugMessageGeneric(c);
        }

        //---generic---
        public void DebugMessageGeneric<T>(T input)
        {
            Debug.Log(transform.name + " reported value: " + input.ToString());
        }
    }
}
