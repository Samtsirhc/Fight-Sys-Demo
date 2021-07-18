using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventCenter
{
    private static Dictionary<EventType, Delegate> myEventTable = new Dictionary<EventType, Delegate>();

    // add listener
    private static void _AddListener(EventType event_type, Delegate call_back)
    {
        if (!myEventTable.ContainsKey(event_type))
        {
            myEventTable.Add(event_type, null);
        }
        Delegate _d = myEventTable[event_type];
        if (_d != null && _d.GetType() != call_back.GetType())
        {
            throw new Exception(string.Format("[{0}] Event type or paras wrong", event_type));
        }
    }
    // 0 para
    public static void AddListener(EventType event_type, CallBack call_back)
    {
        _AddListener(event_type, call_back);
        myEventTable[event_type] = (CallBack)myEventTable[event_type] + call_back;
    }
    // 1 para
    public static void AddListener<T>(EventType event_type, CallBack<T> call_back)
    {
        _AddListener(event_type, call_back);
        myEventTable[event_type] = (CallBack<T>)myEventTable[event_type] + call_back;
    }
    // 2 para
    public static void AddListener<T, X>(EventType event_type, CallBack<T, X> call_back)
    {
        _AddListener(event_type, call_back);
        myEventTable[event_type] = (CallBack<T, X>)myEventTable[event_type] + call_back;
    }
    // 3 para
    public static void AddListener<T, X, Y>(EventType event_type, CallBack<T, X, Y> call_back)
    {
        _AddListener(event_type, call_back);
        myEventTable[event_type] = (CallBack<T, X, Y>)myEventTable[event_type] + call_back;
    }
    // remove listener
    private static void _RemoveListener(EventType event_type, Delegate call_back)
    {
        if (myEventTable.ContainsKey(event_type))
        {
            Delegate _d = myEventTable[event_type];
            if (_d == null)
            {
                throw new Exception(string.Format("[{0}] Delegation did not exist!", event_type));
            }
            else if (_d.GetType() != call_back.GetType())
            {
                throw new Exception(string.Format("[{0}] Event type wrong", event_type));
            }
            myEventTable.Add(event_type, null);
        }
        else
        {
            throw new Exception(string.Format("[{0}] Event did not exist!", event_type));
        }
    }
    // 0 para
    public static void RemoveListener(EventType event_type, CallBack call_back)
    {

        _RemoveListener(event_type, call_back);
        myEventTable[event_type] = (CallBack)myEventTable[event_type] - call_back;
    }
    // 1 para
    public static void RemoveListener<T>(EventType event_type, CallBack<T> call_back)
    {
        _RemoveListener(event_type, call_back);
        myEventTable[event_type] = (CallBack<T>)myEventTable[event_type] - call_back;
    }
    // 2 para
    public static void RemoveListener<T, X>(EventType event_type, CallBack<T, X> call_back)
    {
        _RemoveListener(event_type, call_back);
        myEventTable[event_type] = (CallBack<T, X>)myEventTable[event_type] - call_back;
    }
    // 3 para
    public static void RemoveListener<T, X, Y>(EventType event_type, CallBack<T, X, Y> call_back)
    {
        _RemoveListener(event_type, call_back);
        myEventTable[event_type] = (CallBack<T, X, Y>)myEventTable[event_type] - call_back;
    }
    // broadcast
    //0 para
    public static void Broadcast(EventType event_type)
    {
        Delegate _d;
        if (myEventTable.TryGetValue(event_type, out _d))
        {
            CallBack call_back = _d as CallBack;
            if (call_back != null)
            {
                call_back();
            }
            else
            {
                throw new Exception(string.Format("[{0}] Callback is null", event_type));
            }
        }
    }

    // 1 para
    public static void Broadcast<T>(EventType event_type, T arg)
    {
        Delegate _d;
        if (myEventTable.TryGetValue(event_type, out _d))
        {
            CallBack<T> call_back = _d as CallBack<T>;
            if (call_back != null)
            {
                call_back(arg);
            }
            else
            {
                throw new Exception(string.Format("[{0}] Callback is null", event_type));
            }
        }
    }
    // 2 para
    public static void Broadcast<T, X>(EventType event_type, T arg1, X arg2)
    {
        Delegate _d;
        if (myEventTable.TryGetValue(event_type, out _d))
        {
            CallBack<T, X> call_back = _d as CallBack<T, X>;
            if (call_back != null)
            {
                call_back(arg1, arg2);
            }
            else
            {
                throw new Exception(string.Format("[{0}] Callback is null", event_type));
            }
        }
    }
    // 3 para
    public static void Broadcast<T, X, Y>(EventType event_type, T arg1, X arg2, Y arg3)
    {
        Delegate _d;
        if (myEventTable.TryGetValue(event_type, out _d))
        {
            CallBack<T, X, Y> call_back = _d as CallBack<T, X, Y>;
            if (call_back != null)
            {
                call_back(arg1, arg2, arg3);
            }
            else
            {
                throw new Exception(string.Format("[{0}] Callback is null", event_type));
            }
        }
    }
}
