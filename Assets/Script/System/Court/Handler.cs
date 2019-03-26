using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Handler 
{
    protected Handler m_NextHandler;

    public Handler(Handler theNextHandler)
    {
        m_NextHandler = theNextHandler;
    }

    public virtual void HandleRequest(string type)
    {
        if (m_NextHandler != null)
        {
            m_NextHandler.HandleRequest(type);
        }
    }
}
